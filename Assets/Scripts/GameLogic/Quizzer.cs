using QuizBot.Data;
using QuizBot.UIControllers;
using QuizBot.UIControllers.Reusable;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuizBot.GameLogic
{
    public class Quizzer : MonoBehaviour
    {
        [SerializeField]
        private TextController _questionController = null;

        [SerializeField]
        private ScoreBoard _scoreBoard = null;

        [SerializeField]
        private SelectableTextListController _answerController = null;

        private QuestionAndAnswer CurrentQuestionAndAnswer { get; set; }

        private int SelectedAnswerIndex { get; set; }

        private void Awake()
        {
            ResetScore();
        }

        public void InitializeQuestion(QuestionAndAnswer questionAndAnswer)
        {
            CurrentQuestionAndAnswer = questionAndAnswer;

            _questionController.Refresh(questionAndAnswer.Question);
            _answerController.Refresh(questionAndAnswer.Answers);
        }

        public void SelectAnswer(int index)
        {
            SelectedAnswerIndex = index;
        }

        private void ResetScore()
        {
            _scoreBoard.Set(0);
        }

    }
}