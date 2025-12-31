using MyPractice.Examples.Interfaces;
using System;
using UnityEngine;

namespace MyPractice.Examples.Services
{
    public class ScoreService : IScoreService
    {
        #region Variables
        public event Action<int> ScoreChanged;
        public int CurrentScore { get; private set; }

        private readonly IGameSettings _gameSettings;
        #endregion

        #region Custom Methods
        public ScoreService(IGameSettings gameSettings)
        {
            _gameSettings = gameSettings;
        }

        public void AddScore()
        {
            CurrentScore += _gameSettings.PointsPerHit;
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
