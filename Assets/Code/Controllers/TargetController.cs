using System;
using System.Threading;
using Cysharp.Threading.Tasks;
using MyPractice.Examples.Interfaces;
using UnityEngine;

namespace MyPractice.Examples.Controllers
{
    public class TargetController : ITargetController, IDisposable
    {
        #region Variables
        public event Action TargetGotHit;
        public event Action TargetDespawned;

        public bool CanSpawnTarget => !_view.HasTarget 
                                        && Time.time - _lastTimeDespawned >= _gameSettings.TargetSpawnCoolDownInSeconds;

        private readonly IGameSettings _gameSettings;

        private ITargetView _view;
        private float _lastTimeDespawned;
        private CancellationTokenSource _despawnCancellationSource;
        #endregion

        #region BuiltIn Methods
        #endregion

        #region Custom Methods

        public TargetController(IGameSettings gameSettings)
        {
            _gameSettings = gameSettings;
        }
        public void SetView(ITargetView view)
        {
            if (_view != null)
            {
                _view.TargetGotHit -= OnTargetGotHit;
            }

            _view = view;
            _view.TargetGotHit += OnTargetGotHit;
            _lastTimeDespawned = Time.timeScale - _gameSettings.TargetSpawnCoolDownInSeconds;
        }

        private void OnTargetGotHit()
        {
            Despawn();
            TargetGotHit?.Invoke();
        }

        private void Despawn()
        {
            _lastTimeDespawned = Time.time;
            _view.DespawnTarget();
            CancelDespawnTimer();
        }

        public void SpawnTarget()
        {
            if (!CanSpawnTarget)
            {
                return;
            }

            CancelDespawnTimer();
            _view.SpawnTarget();

            _despawnCancellationSource = new CancellationTokenSource();
            DespawnAfterDelay(_gameSettings.DespawnTargetAfterSeconds, _despawnCancellationSource.Token).Forget();
        }

        private async UniTaskVoid DespawnAfterDelay(float seconds, CancellationToken token)
        {
            try
            {
                await UniTask.Delay(TimeSpan.FromSeconds(seconds), cancellationToken: token);
                if (token.IsCancellationRequested || !_view.HasTarget)
                {
                    return;
                }

                Despawn();
                TargetDespawned?.Invoke();
            }
            catch (OperationCanceledException)
            {
                // ignored: countdown canceled
            }
        }

        private void CancelDespawnTimer()
        {
            _despawnCancellationSource?.Cancel();
            _despawnCancellationSource?.Dispose();
            _despawnCancellationSource = null;
        }

        public void Dispose()
        {
            CancelDespawnTimer();
        }
        #endregion
    }
}
