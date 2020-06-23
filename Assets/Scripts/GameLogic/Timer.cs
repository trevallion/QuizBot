using QuizBot.UIControllers.Reusable;
using System.Collections;
using UnityEngine;

namespace QuizBot.GameLogic
{
    public class Timer : MonoBehaviour
    {
        private const string TimerStringFormat = "F2";

        [SerializeField]
        private TextController _timerTextController = null;

        public IEnumerator RunTimer(float duration)
        {
            var startTime = Time.time;

            while (Time.time < startTime + duration)
            {
                var timeRemaining = duration - (Time.time - startTime);
                _timerTextController.Refresh(timeRemaining.ToString(TimerStringFormat));
                yield return null;
            }
            _timerTextController.Refresh(0.ToString(TimerStringFormat));
        }
    }
}