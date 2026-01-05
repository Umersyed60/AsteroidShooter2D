using MyPractice.Examples.Views;
using NUnit.Framework;
using PlayModeTests.Mocks;
using System.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.TestTools;

namespace PlayModeTests
{
    [TestFixture]
    public class BulletIntegrationTests
    {
        private readonly BulletView _bulletPrefab;
        private readonly TargetView _targetPrefab;

        private BulletView _bullet;
        private TargetView _target;
        private Camera _camera;

        public BulletIntegrationTests()
        {
            _bulletPrefab = AssetDatabase.LoadAssetAtPath<BulletView>("Assets/Prefabs/Bullet.prefab");
            _targetPrefab = AssetDatabase.LoadAssetAtPath<TargetView>("Assets/Prefabs/Target Spawn Point.prefab");

            Application.targetFrameRate = 60;
            Time.fixedDeltaTime = 1f / 60;
        }

        [SetUp]
        public void Setup()
        {
            var cameraObj = new GameObject("Camera");
            _camera = cameraObj.AddComponent<Camera>();
            _camera.transform.position = new Vector3(0, 0, -14);

            _bullet = Object.Instantiate(_bulletPrefab);
            _bullet.Construct(new MockBulletsService());

            _target = Object.Instantiate(_targetPrefab);
            _target.TargetGotHit += OnTargetHit;
        }

        [TearDown]
        public void TearDown()
        {
            if (_bullet)
            {
                Object.DestroyImmediate(_bullet.gameObject);
            }

            if (_target)
            {
                _target.TargetGotHit -= OnTargetHit;
                Object.DestroyImmediate(_target.gameObject);
            }

            if (_camera)
            {
                Object.DestroyImmediate(_camera);
            }
        }

        [UnityTest]
        public IEnumerator Bullet_CollidesWithTarget_BothDespawned()
        {
            //Arrange
            const float duration = 3f;

            _bullet.transform.position = new Vector2(10, 0);
            _target.transform.position = new Vector2(-10, 0);

            _bullet.SetMovementDirection(Vector2.left);
            _target.SpawnTarget();

            yield return null;

            //Making sure that arrangement is correct
            Assert.That(_target.HasTarget, Is.True);

            //Act - Just Wait
            yield return new WaitForSeconds(duration);

            //Assert
            Assert.That(_bullet == null, Is.True, "Bullet is not destroyed");
            Assert.That(_target.HasTarget, Is.False, "Target wasn't despawned");
        }

        private void OnTargetHit()
        {
            _target.DespawnTarget();
        }
    }
}
