using QuizBot.Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuizBot.GameLogic
{
    public class Quizzer : MonoBehaviour
    {
        private const float DefaultQuestionDuration = 10f;

        [SerializeField]
        private ScoreBoard _scoreBoard = null;

        [SerializeField]
        private Timer _timer = null;

        [SerializeField]
        private QuestionAsker _questionAsker = null;

        private List<QuestionAndAnswer> QuizQuestions { get; set; }

        private void Awake()
        {
            ResetScore();
            var newQuestion = new QuestionAndAnswer()
            {
                Question = "What kind of bear is best?",
                Answers = new List<string>
                {
                    "Bears",
                    "Beets",
                    "Battlestar Galactica",
                    "Grizzly"
                },
                CorrectAnswerIndex = 3,
                ScoreValue = 10
            };
            var quizQuestions = new List<QuestionAndAnswer> { newQuestion };
            StartQuiz(quizQuestions);
        }

        public void StartQuiz(List<QuestionAndAnswer> quizQuestions)
        {
            if(quizQuestions == null || quizQuestions.Count == 0)
            {
                Debug.LogError("Error: no quiz questions provided!");
                return;
            }

            QuizQuestions = quizQuestions;
            StartCoroutine(RunQuiz());
        }

        private IEnumerator RunQuiz()
        {
            foreach(var questionAndAnswer in QuizQuestions)
            {
                yield return StartCoroutine(AskQuestion(questionAndAnswer));
                if (_questionAsker.IsSelectedAnswerCorrect)
                {
                    _scoreBoard.AddToScore(questionAndAnswer.ScoreValue);
                }
                else
                {
                    _scoreBoard.AddToScore(-questionAndAnswer.ScoreValue);
                }
            }
        }

        private IEnumerator AskQuestion(QuestionAndAnswer questionAndAnswer)
        {
            _questionAsker.InitializeQuestion(questionAndAnswer);
            yield return StartCoroutine(_timer.RunTimer(DefaultQuestionDuration));
        }

        private void ResetScore()
        {
            _scoreBoard.Set(0);
        }
    }
}