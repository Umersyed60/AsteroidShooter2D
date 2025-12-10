using System;
namespace MyPractice.Examples.Interfaces
{
    public interface IScoreService
    {
        #region Variables
        event Action<int> ScoreChanged;
        int CurrentScore { get; }
        #endregion

        #region Custom Methods
        void AddScore();
        void SubtractScore();
        #endregion
    }

}
