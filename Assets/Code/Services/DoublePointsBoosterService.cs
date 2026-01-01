using MyPractice.Examples.Interfaces;
using UnityEngine;

namespace MyPractice.Examples.Services
{
    public class DoublePointsBoosterService : IBoosterService
    {
        #region Variables
        public int Multiplier => ShouldApplyBooster() ? 2 : 1;

        private readonly IGameSettings _gameSettings;
        #endregion

        #region Custom Methods
        public DoublePointsBoosterService(IGameSettings gameSettings)
        {
            _gameSettings = gameSettings;
        }

        private bool ShouldApplyBooster()
        {
            if (!_gameSettings.EnableScoreBoosters)
            {
                return false;
            }

            return Random.Range(0f, 1f) < _gameSettings.BoosterChance;
        }
        #endregion
    }
}
