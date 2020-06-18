using QuizBot.UIControllers.BaseClasses;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace QuizBot.UIControllers
{
    public class ScoreController : UIController<int>
    {
        [SerializeField]
        private TMP_Text _scoreText = null;

        public int Score { get; private set; }

        public override void Refresh(int data)
        {
            Score = data;
            _scoreText.text = data.ToString();
        }

        public void AddToScore(int amountToAdd)
        {
            Refresh(Score + amountToAdd);
        }
    }
}