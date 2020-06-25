using QuizBot.Data;
using QuizBot.UIControllers.Reusable;
using System.Collections;
using UnityEngine;

namespace QuizBot.GameLogic
{
    /// <summary>
    /// Passes Q&A content to UI controllers and determines if the currently selected answer is correct.
    /// </summary>
    public class QuestionAsker : MonoBehaviour
    {
        private const float DefaultQuestionDuration = 10f;
        private const int DefaultAnswerIndex = -1;

        [SerializeField]
        private TextController _questionController = null;

        [SerializeField]
        private SelectableTextListController _answerController = null;

        [SerializeField]
        private Timer _timer = null;

        public bool IsSelectedAnswerCorrect => CurrentQuestionAndAnswer != null &&
            SelectedAnswerIndex == CurrentQuestionAndAnswer.CorrectAnswerIndex;

        private QuestionAndAnswer CurrentQuestionAndAnswer { get; set; }

        private Coroutine TimerCoroutine { get; set; }

        private int SelectedAnswerIndex { get; set; }

        private bool WasQuestionAnswered { get; set; }

        public IEnumerator AskQuestion(QuestionAndAnswer questionAndAnswer)
        {
            CurrentQuestionAndAnswer = questionAndAnswer;
            SelectedAnswerIndex = DefaultAnswerIndex;
            WasQuestionAnswered = false;

            _questionController.Refresh(questionAndAnswer.Question);
            _answerController.Refresh(questionAndAnswer.Answers);

            TimerCoroutine = StartCoroutine(_timer.RunTimer(DefaultQuestionDuration));

            while (_timer.TimeRemaining > 0 && !WasQuestionAnswered)
            {
                yield return null;
            }

            if (TimerCoroutine != null)
            {
                StopCoroutine(TimerCoroutine);
            }
        }

        public void SelectAnswer(int index)
        {
            // TODO: Lock out answers after selection is made.
            SelectedAnswerIndex = index;
            WasQuestionAnswered = true;
        }
    }
}