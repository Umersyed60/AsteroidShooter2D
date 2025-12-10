using MyPractice.Examples.Interfaces;
using UnityEngine;

namespace MyPractice.Examples.Handlers
{
    public class KeyboardInputHandler : IInputHandler
    {
        #region Variables
        private readonly IControlsSettings _controlsSettings;
        #endregion

        #region Properties
        public float AimDirection => GetAimDirection();
        public bool IsFireButtonPressed => Input.GetKeyDown(_controlsSettings.FireKey);
        #endregion

        #region Custom Methods
        public KeyboardInputHandler(IControlsSettings controlsSettings)
        {
            _controlsSettings = controlsSettings;
        }

        private float GetAimDirection()
        {
            return Input.anyKey switch
            {
                true when Input.GetKey(_controlsSettings.AimLeftKey) => 1f,
                true when Input.GetKey(_controlsSettings.AimRightKey) => -1f,
                _ => 0f
            };
        }
        #endregion
    }
}