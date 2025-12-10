using MyPractice.Examples.Settings;
using MyPractice.Examples.Handlers;
using MyPractice.Examples.Interfaces;
using MyPractice.Examples.Controllers;
using UnityEngine;
using VContainer;
using VContainer.Unity;

namespace MyPractice.Examples
{
    public class GameLifetimeScope : LifetimeScope
    {
        [SerializeField] private ControlsSettings _controlsSettings;

        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<IInputHandler, KeyboardInputHandler>(Lifetime.Singleton);

            builder.RegisterInstance(_controlsSettings).As<IControlsSettings>();

            builder.UseEntryPoints(config =>
            {
                config.Add<PlayerController>();
            });
        }
    }

}