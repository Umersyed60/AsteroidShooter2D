using MyPractice.Examples.Views;
using UnityEngine;

namespace MyPractice.Examples.Interfaces
{
    public interface IBulletsService
    {
        #region Custom Methods
        void SpawnBullet(Vector2 direction);
        void DespawnBullet(BulletView bullet);
        #endregion
    }

}