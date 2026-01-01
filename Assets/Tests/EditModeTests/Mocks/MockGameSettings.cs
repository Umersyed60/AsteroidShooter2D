using MyPractice.Examples.Interfaces;

namespace EditModeTests.Mocks
{
    public class MockGameSettings : IGameSettings
    {
        public int PointsPerHit { get; set; } = 10;

        public int PointsPerMiss { get; set; } = -5;

        public float AimRotationDegreesPerSecond { get; set; } = 60;

        public float DespawnTargetAfterSeconds { get; set; } = 5f;

        public float TargetSpawnCoolDownInSeconds { get; set; } = 4f;
    }
}
