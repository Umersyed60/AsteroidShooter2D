using EditModeTests.Mocks;
using MyPractice.Examples.Services;
using NUnit.Framework;

namespace EditModeTests
{
    [TestFixture]
    public class ScoreServiceTests
    {
        private ScoreService _scoreService;
        private MockGameSettings _mockSettings;
        private MockBoosterService _mockboosterService;

        [SetUp]
        public void Setup()
        {
            _mockSettings = new MockGameSettings
            {
                PointsPerHit = 100,
                PointsPerMiss = -50
            };

            _mockboosterService = new MockBoosterService
            {
                Multiplier = 1
            };

            _scoreService = new ScoreService(_mockSettings, _mockboosterService);
        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        public void AddScore_WithMultiplier_IncreasesPoints(int multiplier)
        {
            //Arrange
            _mockboosterService.Multiplier = multiplier;
            _mockSettings.BoosterChance = 1f;
            _mockSettings.EnableScoreBoosters = true;
            var initialScore = _scoreService.CurrentScore;
            var boosterMultiplier = _mockboosterService.Multiplier;
            var expectedScore = initialScore + (_mockSettings.PointsPerHit * boosterMultiplier);

            //Act
            _scoreService.AddScore();

            //Assert
            Assert.AreEqual(expectedScore, _scoreService.CurrentScore);
        }

        [Test]
        public void AddScore_IncreasesScoreByPointsPerHit()
        {
            //Arrange
            var initialScore = _scoreService.CurrentScore;
            var expectedScore = initialScore + _mockSettings.PointsPerHit;

            //Act
            _scoreService.AddScore();

            //Assert
            Assert.AreEqual(expectedScore, _scoreService.CurrentScore);
        }

        [Test]
        public void AddScore_MultipleCalls_AccumulatesCorrectly()
        {
            //Arrange
            const int hits = 3;
            var expectedScore = hits * _mockSettings.PointsPerHit;

            //Act
            for (var i =0; i < hits; i++)
            {
                _scoreService.AddScore();
            }

            //Assert
            Assert.AreEqual(expectedScore, _scoreService.CurrentScore);
        }

        [Test]
        public void SubtractScore_DecreasesScoreByPointsPerMiss()
        {
            //Arrange
            _scoreService.AddScore();
            var initialScore = _scoreService.CurrentScore;
            var expectedScore = initialScore + _mockSettings.PointsPerMiss;

            //Act
            _scoreService.SubtractScore();

            //Assert
            Assert.AreEqual(expectedScore, _scoreService.CurrentScore);
        }
    }
}
