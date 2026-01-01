using MyPractice.Examples.Interfaces;
using UnityEngine;

namespace MyPractice.Examples.Settings
{
    [CreateAssetMenu(fileName = "Game Settings", menuName = "My Practice/Game Settings", order = 0)]
    public class GameSettings : ScriptableObject, IGameSettings
    {
        #region Variables
        [field: SerializeField] public int PointsPerHit { get; set; }

        [field: SerializeField] public int PointsPerMiss { get; set; }

        [field: SerializeField] public float AimRotationDegreesPerSecond { get; set; }

        [field: SerializeField] public float DespawnTargetAfterSeconds { get; set; }

        [field: SerializeField] public float TargetSpawnCoolDownInSeconds { get; set; }

        [field: SerializeField] public bool EnableScoreBoosters { get; set; } = false;

        [field: SerializeField] public float BoosterChance { get; set; } = 0.3f;
        #endregion
    }
}

