using System;

namespace MyPractice.Examples.Interfaces
{
    public interface ITargetController
    {
        #region Variables
        event Action TargetGotHit;
        event Action TargetDespawned;
        bool CanSpawnTarget { get; }
        #endregion

        #region Custom Methods
        void SetView(ITargetView view);
        void SpawnTarget();
        #endregion
    }

}