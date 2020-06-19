using QuizBot.UIControllers.BaseClasses;
using QuizBot.UIControllers.Reusable;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

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