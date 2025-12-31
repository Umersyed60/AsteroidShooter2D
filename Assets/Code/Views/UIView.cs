using MyPractice.Examples.Interfaces;
using System;
using TMPro;
using UnityEngine;
using VContainer;

namespace MyPractice.Examples.Views
{
    public class UIView : MonoBehaviour
    {
        #region Variables
        [SerializeField] private TextMeshProUGUI _scoreText;
        [SerializeField] private TextMeshProUGUI _timeText;

        private ITimeService _timeService;
        private IScoreService _scoreService;
        #endregion

        #region BuiltIn Methods
        private void Awake()
        {
            _timeService.SecondPassed += OnSecondPassed;
            _scoreService.ScoreChanged += OnScoreChanged;
        }

        private void OnDestroy()
        {
            _timeService.SecondPassed -= OnSecondPassed;
            _scoreService.ScoreChanged -= OnScoreChanged;
        }
        #endregion

        #region Custom Methods
        [Inject]
        public void Construct(ITimeService timeService, IScoreService scoreService)
        {
            _timeService = timeService;
            _scoreService = scoreService;
        }

        private void OnScoreChanged(int newScore)
        {
            _scoreText.text = $"Score: {newScore}";
        }

        private void OnSecondPassed()
        {
            var timePassed = TimeSpan.FromSeconds(_timeService.SecondsPassed);
            _timeText.text = $"Time: {timePassed:mm\\:ss}";
        }

        #endregion
    }
}
