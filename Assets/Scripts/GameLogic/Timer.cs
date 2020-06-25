using QuizBot.UIControllers.Reusable;
using System.Collections;
using UnityEngine;

namespace QuizBot.GameLogic
{
    public class Timer : MonoBehaviour
    {
        private const string TimerStringFormat = "F2";

        public float TimeRemaining { get; set; }

        [SerializeField]
        private TextController _timerTextController = null;

        public IEnumerator RunTimer(float duration)
        {
            var startTime = Time.time;

            while (Time.time < startTime + duration)
            {
                TimeRemaining = duration - (Time.time - startTime);
                UpdateTimerText();
                yield return null;
            }

            TimeRemaining = 0;
            UpdateTimerText();
        }

        private void UpdateTimerText()
        {
            _timerTextController.Refresh(TimeRemaining.ToString(TimerStringFormat));
        }
    }
}