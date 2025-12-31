using MyPractice.Examples.Interfaces;
using System;
using UnityEngine;
using VContainer.Unity;

namespace MyPractice.Examples.Services
{
    public class TimeService : ITimeService, ITickable
    {
        #region Variables
        public event Action SecondPassed;
        public int SecondsPassed { get; private set; }

        private float _elapsedTime;
        #endregion

        #region BuiltIn Methods
        #endregion

        #region Custom Methods
        public void Tick()
        {
            _elapsedTime += Time.deltaTime;

            if (_elapsedTime < 1f)
            {
                return;
            }

            _elapsedTime = 0f;
            SecondsPassed++;
            SecondPassed?.Invoke();
        }
        #endregion
    }
}
