using QuizBot.UIControllers.Reusable;
using UnityEngine;

namespace QuizBot.GameLogic
{
    public class ScoreBoard : MonoBehaviour
    {
        [SerializeField]
        private TextController _scoreTextController = null;

        public int Score { get; private set; }

        public void Set(int newScore)
        {
            Score = newScore;
            _scoreTextController.Refresh(newScore.ToString());
        }

        public void AddToScore(int amountToAdd)
        {
            Set(Score + amountToAdd);
        }
    }
}