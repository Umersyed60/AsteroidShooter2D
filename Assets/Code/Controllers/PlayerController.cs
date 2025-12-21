using MyPractice.Examples.Interfaces;
using VContainer.Unity;
using UnityEngine;

namespace MyPractice.Examples.Controllers
{
    public class PlayerController : IPlayerController, ITickable
    {
        #region Variables
        private readonly IInputHandler _inputHandler;
        private readonly IGameSettings _gameSettings;
        private readonly IPlayerView _playerView;
        #endregion

        #region Custom Methods
        public PlayerController(IInputHandler inputHandler, IGameSettings gameSettings, IPlayerView playerView)
        {
            _inputHandler = inputHandler;
            _gameSettings = gameSettings;
            _playerView = playerView;
        }

        public void Tick()
        {
            if (!Mathf.Approximately(_inputHandler.AimDirection, 0f))
            {
                //Debug.Log($"Aim Direction: {_inputHandler.AimDirection}");
                _playerView.CannonRotation += _gameSettings.AimRotationDegreesPerSecond * Time.deltaTime * _inputHandler.AimDirection;
            }

            if (_inputHandler.IsFireButtonPressed)
            {
                Debug.Log("Fire Button Pressed");
            }
        }
        #endregion
    }
}
