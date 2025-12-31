using UnityEngine;
using MyPractice.Examples.Interfaces;
using VContainer;

namespace MyPractice.Examples.Views
{
    public class BulletView : MonoBehaviour
    {
        #region Variables
        [SerializeField] private float _speed = 10f;
        [SerializeField] private Rigidbody2D _rigidbody;

        private Vector2 _moveDirection = Vector2.right;

        private IBulletsService _bulletsService;
        #endregion

        #region BuiltIn Methods
        private void OnEnable() => StartMovement();

        private void OnTriggerEnter2D(Collider2D collision) => _bulletsService.DespawnBullet(this);
        #endregion

        #region Custom Methods
        [Inject]
        public void Construct(IBulletsService bulletsService)
        {
            _bulletsService = bulletsService;
        }

        public void SetMovementDirection(Vector2 direction)
        {
            _moveDirection = direction;
            StartMovement();
        }

        private void StartMovement()
        {
            _rigidbody.linearVelocity = _moveDirection.normalized * _speed;
            var angle = Mathf.Atan2(_moveDirection.y, _moveDirection.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
        #endregion
    }
}
