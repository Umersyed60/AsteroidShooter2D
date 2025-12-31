using UnityEngine;
using MyPractice.Examples.Interfaces;
using System;

namespace MyPractice.Examples.Views
{
    public class TargetView : MonoBehaviour, ITargetView
    {
        #region Variables
        public event Action TargetGotHit;
        public bool HasTarget => _target.activeInHierarchy;

        [SerializeField] private GameObject _target;
        [SerializeField] private Collider2D _collider;
        #endregion

        #region BuiltIn Methods
        private void Awake() => DespawnTarget();

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (!HasTarget)
            {
                return;
            }

            TargetGotHit?.Invoke();
        }
        #endregion

        #region Custom Methods
        public void SpawnTarget()
        {
            _target.SetActive(true);
            _collider.enabled = true;
        }

        public void DespawnTarget()
        {
            _target.SetActive(false);
            _collider.enabled = false;
        }
        #endregion
    }
}
