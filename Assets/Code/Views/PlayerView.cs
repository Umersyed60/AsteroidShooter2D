using MyPractice.Examples.Interfaces;
using UnityEngine;

namespace MyPractice.Examples.Views
{
    public class PlayerView : MonoBehaviour, IPlayerView
    {
        #region Variables
        [SerializeField] private Transform _cannon;
        public float CannonRotation
        {
            get => _cannon.eulerAngles.z;
            set => _cannon.eulerAngles = new Vector3(0f, 0f, value);
        }
        #endregion

        #region Custom Methods
        #endregion
    }
}

