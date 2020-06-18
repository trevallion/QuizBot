using QuizBot.UIControllers.BaseClasses;
using QuizBot.UnityEvents;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

namespace QuizBot.UIControllers
{
    public class AnswerController : UIController<Answer>
    {
        private const string letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        public UnityEventInt AnswerSelected;

        [SerializeField]
        private TMP_Text _answerLabelText = null;

        [SerializeField]
        private TMP_Text _answerText = null;

        private int AnswerIndex { get; set; }

        public override void Refresh(Answer data)
        {
            _answerText.text = data.AnswerText;
        }

        public void OnAnswerToggleClicked(bool toggleOn)
        {
            if (toggleOn)
            {
                AnswerSelected?.Invoke(AnswerIndex);
            }
        }

        public void Initialize(int index)
        {
            AnswerIndex = index;
            
            if(index < letters.Length)
            {
                _answerLabelText.text = letters[index].ToString();
            }
        }
    }
}