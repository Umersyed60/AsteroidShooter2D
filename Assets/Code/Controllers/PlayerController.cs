using MyPractice.Examples.Interfaces;
using VContainer.Unity;
using UnityEngine;

namespace MyPractice.Examples.Controllers
{
    public class PlayerController : IPlayerController, ITickable
    {
        #region Variables
        private readonly IInputHandler _inputHandler;
        #endregion

        #region Custom Methods
        public PlayerController(IInputHandler inputHandler)
        {
            _inputHandler = inputHandler;
        }

        public void Tick()
        {
            if (!Mathf.Approximately(_inputHandler.AimDirection, 0f))
            {
                Debug.Log($"Aim Direction: {_inputHandler.AimDirection}");
            }

            if (_inputHandler.IsFireButtonPressed)
            {
                Debug.Log("Fire Button Pressed");
            }
        }
        #endregion
    }
}
