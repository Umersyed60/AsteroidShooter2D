using MyPractice.Examples.Settings;
using MyPractice.Examples.Handlers;
using MyPractice.Examples.Interfaces;
using MyPractice.Examples.Controllers;
using MyPractice.Examples.Views;
using MyPractice.Examples.Services;
using MyPractice.Examples.Utils;
using UnityEngine;
using VContainer;
using VContainer.Unity;


namespace MyPractice.Examples
{
    public class GameLifetimeScope : LifetimeScope
    {
        [Header("Settings")]
        [SerializeField] private ControlsSettings _controlsSettings;
        [SerializeField] private GameSettings _gameSettings;

        [Header("Views")]
        [SerializeField] private PlayerView _playerView;
        [SerializeField] private BulletView _bulletViewPrefab;

        [Header("Various")]
        [SerializeField] private Transform _bulletSpawnPoint;
        [SerializeField] private TargetView[] _targetSpawnPointViews;

        protected override void Configure(IContainerBuilder builder)
        {
            //Services
            builder.Register<IBulletsService, BulletsService>(Lifetime.Singleton);
            builder.Register<IScoreService, ScoreService>(Lifetime.Singleton);
            builder.Register<IBoosterService, DoublePointsBoosterService>(Lifetime.Singleton);

            //Various
            builder.Register<IInputHandler, KeyboardInputHandler>(Lifetime.Singleton); //VContainer builds this instance on request
            builder.RegisterInstance(_bulletSpawnPoint).Keyed(TransformKey.BulletSpawn);
            builder.Register<ITargetController, TargetController>(Lifetime.Transient);

            //Settings
            builder.RegisterInstance(_controlsSettings).As<IControlsSettings>(); //To register a pre-made object through inspector
            //Just another way of using RegisterInstance
            builder.RegisterInstance<IGameSettings>(_gameSettings);

            //Views
            builder.RegisterComponent(_playerView).As<IPlayerView>(); // To register a MonoBehaviour already in the scene
            builder.RegisterInstance(_bulletViewPrefab);

            foreach (var targetSpawnPointView in _targetSpawnPointViews)
            {
                builder.RegisterInstance<ITargetView>(targetSpawnPointView).Keyed(targetSpawnPointView.name);
            }

            builder.UseEntryPoints(config =>
            {
                config.Add<PlayerController>();
                config.Add<TargetsService>();
                config.Add<TimeService>().As<ITimeService>();
            });
        }
    }

}