using QuizBot.Data;
using QuizBot.GameLogic.QuizProviders;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuizBot.GameLogic
{
    public class Quizzer : MonoBehaviour
    {
        private const float DelayBetweenQuestions = 1f;

#if UNITY_EDITOR
        [SerializeField]
        private LocalQuizQuestions _localQuizQuestions = null;
#endif

        [SerializeField]
        private ScoreBoard _scoreBoard = null;

        [SerializeField]
        private QuestionAsker _questionAsker = null;

        private List<QuestionAndAnswer> QuizQuestions { get; set; }

        private void Awake()
        {
            // TODO: Cache this and wrap it in a preprocessor directive once we have multiple implementations.
            IQuizProvider quizProvider = new LocalQuizProvider(_localQuizQuestions);
            StartQuiz(quizProvider.GetQuizQuestions());
        }

        public void StartQuiz(List<QuestionAndAnswer> quizQuestions)
        {
            if (quizQuestions == null || quizQuestions.Count == 0)
            {
                Debug.LogError("Error: no quiz questions provided!");
                return;
            }

            ResetScore();
            QuizQuestions = quizQuestions;
            StartCoroutine(RunQuiz());
        }

        private IEnumerator RunQuiz()
        {
            foreach(var questionAndAnswer in QuizQuestions)
            {
                yield return StartCoroutine(AskQuestion(questionAndAnswer));
                UpdateScoreForSelectedAnswer(questionAndAnswer.ScoreValue);
                yield return new WaitForSeconds(DelayBetweenQuestions);
            }

            // TODO: Display summary on completion.
        }

        private void UpdateScoreForSelectedAnswer(int scoreValue)
        {
            if (_questionAsker.IsSelectedAnswerCorrect)
            {
                _scoreBoard.AddToScore(scoreValue);
            }
            else
            {
                _scoreBoard.AddToScore(-scoreValue);
            }
        }

        private IEnumerator AskQuestion(QuestionAndAnswer questionAndAnswer)
        {
            yield return StartCoroutine(_questionAsker.AskQuestion(questionAndAnswer));
        }

        private void ResetScore()
        {
            _scoreBoard.Set(0);
        }
    }
}