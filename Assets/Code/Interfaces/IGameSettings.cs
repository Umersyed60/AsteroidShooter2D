namespace MyPractice.Examples.Interfaces
{
    public interface IGameSettings
    {
        #region Variables
        int PointsPerHit { get; }
        int PointsPerMiss { get; }
        float AimRotationDegreesPerSecond { get; }
        float DespawnTargetAfterSeconds { get; }
        float TargetSpawnCoolDownInSeconds { get; }
        #endregion
    }

}
