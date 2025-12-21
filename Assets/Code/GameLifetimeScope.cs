using MyPractice.Examples.Settings;
using MyPractice.Examples.Handlers;
using MyPractice.Examples.Interfaces;
using MyPractice.Examples.Controllers;
using MyPractice.Examples.Views;
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

        protected override void Configure(IContainerBuilder builder)
        {
            //Various
            builder.Register<IInputHandler, KeyboardInputHandler>(Lifetime.Singleton); //VContainer builds this instance on request

            //Settings
            builder.RegisterInstance(_controlsSettings).As<IControlsSettings>(); //To register a pre-made object through inspector
            //Just another way of using RegisterInstance
            builder.RegisterInstance<IGameSettings>(_gameSettings);

            //Views
            builder.RegisterComponent(_playerView).As<IPlayerView>(); // To register a MonoBehaviour already in the scene

            builder.UseEntryPoints(config =>
            {
                config.Add<PlayerController>();
            });
        }
    }

}