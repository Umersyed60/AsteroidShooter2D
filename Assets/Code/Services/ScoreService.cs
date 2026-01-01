using MyPractice.Examples.Interfaces;
using System;

namespace MyPractice.Examples.Services
{
    public class ScoreService : IScoreService
    {
        #region Variables
        public event Action<int> ScoreChanged;
        public int CurrentScore { get; private set; }

        private readonly IGameSettings _gameSettings;
        private readonly IBoosterService _boosterService;
        #endregion

        #region Custom Methods
        public ScoreService(IGameSettings gameSettings, IBoosterService boosterService)
        {
            _gameSettings = gameSettings;
            _boosterService = boosterService;
        }

        public void AddScore()
        {
            CurrentScore += _gameSettings.PointsPerHit * _boosterService.Multiplier;
            ScoreChanged?.Invoke(CurrentScore);
        }

        public void SubtractScore()
        {
            CurrentScore += _gameSettings.PointsPerMiss;
            ScoreChanged?.Invoke(CurrentScore);
        }
        #endregion
    }
}
