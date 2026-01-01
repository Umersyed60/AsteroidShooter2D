using EditModeTests.Mocks;
using MyPractice.Examples.Services;
using NUnit.Framework;

namespace EditModeTests
{
    [TestFixture]
    public class ScoreServiceTests
    {
        private ScoreService _scoreService;
        private MockGameSettings _mockSetting;

        [SetUp]
        public void Setup()
        {
            _mockSetting = new MockGameSettings
            {
                PointsPerHit = 100,
                PointsPerMiss = -50
            };
            _scoreService = new ScoreService(_mockSetting);
        }

        [Test]
        public void AddScore_IncreasesScoreByPointsPerHit()
        {
            //Arrange
            var initialScore = _scoreService.CurrentScore;
            var expectedScore = initialScore + _mockSetting.PointsPerHit;

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
            var expectedScore = hits * _mockSetting.PointsPerHit;

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
            var expectedScore = initialScore + _mockSetting.PointsPerMiss;

            //Act
            _scoreService.SubtractScore();

            //Assert
            Assert.AreEqual(expectedScore, _scoreService.CurrentScore);
        }
    }
}
