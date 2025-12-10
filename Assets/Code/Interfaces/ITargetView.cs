using System;
namespace MyPractice.Examples.Interfaces
{
    public interface ITargetView
    {
        #region Variables
        event Action TargetGotHit;
        bool HasTarget { get; }
        #endregion

        #region Custom Methods
        void SpawnTarget();
        void DeSpawnTarget();
        #endregion
    }

}
