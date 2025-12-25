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

        protected override void Configure(IContainerBuilder builder)
        {
            //Services
            builder.Register<IBulletsService, BulletsService>(Lifetime.Singleton);

            //Various
            builder.Register<IInputHandler, KeyboardInputHandler>(Lifetime.Singleton); //VContainer builds this instance on request
            builder.RegisterInstance(_bulletSpawnPoint).Keyed(TransformKey.BulletSpawn);

            //Settings
            builder.RegisterInstance(_controlsSettings).As<IControlsSettings>(); //To register a pre-made object through inspector
            //Just another way of using RegisterInstance
            builder.RegisterInstance<IGameSettings>(_gameSettings);

            //Views
            builder.RegisterComponent(_playerView).As<IPlayerView>(); // To register a MonoBehaviour already in the scene
            builder.RegisterInstance(_bulletViewPrefab);

            builder.UseEntryPoints(config =>
            {
                config.Add<PlayerController>();
            });
        }
    }

}