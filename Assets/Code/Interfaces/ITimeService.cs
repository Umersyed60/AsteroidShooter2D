using System;
namespace MyPractice.Examples.Interfaces
{
    public interface ITimeService
    {
        #region Variables
        event Action SecondPassed;
        int SecondsPassed { get; }
        #endregion
    }

}