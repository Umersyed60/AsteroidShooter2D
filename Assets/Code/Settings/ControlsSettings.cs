using MyPractice.Examples.Interfaces;
using UnityEngine;

namespace MyPractice.Examples.Settings
{

    [CreateAssetMenu(fileName = "ControlsSettings", menuName = "My Practice/Controls Settings", order = 0)]
    public class ControlsSettings : ScriptableObject, IControlsSettings
    {
        #region Variables
        [field: SerializeField] public KeyCode AimLeftKey { get; set; }

        [field: SerializeField] public KeyCode AimRightKey { get; set; }

        [field: SerializeField] public KeyCode FireKey { get; set; }
        #endregion
    }

}