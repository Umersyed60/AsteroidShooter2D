using MyPractice.Examples.Interfaces;
using MyPractice.Examples.Views;
using UnityEngine;

namespace PlayModeTests.Mocks
{
    public class MockBulletsService : IBulletsService
    {
        public void SpawnBullet(Vector2 direction)
        {
            throw new System.NotImplementedException();
        }
        public void DespawnBullet(BulletView bullet)
        {
            Object.Destroy(bullet.gameObject);
        }
    }
}
