using QuizBot.Data;
using QuizBot.UIControllers;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuizBot.GameLogic
{
    public class Quizzer : MonoBehaviour
    {
        [SerializeField]
        private QuestionController _questionController = null;

        [SerializeField]
        private ScoreController _scoreController = null;

        [SerializeField]
        private List<AnswerController> _answerControllers = new List<AnswerController>();

        private QuestionAndAnswer QuestionAndAnswer { get; set; }

        private void Awake()
        {
            for(int i = 0; i < _answerControllers.Count; ++i)
            {
                _answerControllers[i].Initialize(i);
            }

            _scoreController.Refresh(0);
        }
    }
}