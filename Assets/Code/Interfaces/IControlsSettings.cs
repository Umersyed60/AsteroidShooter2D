using UnityEngine;
namespace MyPractice.Examples.Interfaces
{
    public interface IControlsSettings
    {
        #region Variables
        KeyCode AimLeftKey { get; }
        KeyCode AimRightKey { get; }
        KeyCode FireKey { get; }
        #endregion
    }

}