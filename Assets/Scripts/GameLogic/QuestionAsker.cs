using QuizBot.Data;
using QuizBot.UIControllers.Reusable;
using UnityEngine;

namespace QuizBot.GameLogic
{
    public class QuestionAsker : MonoBehaviour
    {
        private const int DefaultAnswerIndex = -1;

        [SerializeField]
        private TextController _questionController = null;

        [SerializeField]
        private SelectableTextListController _answerController = null;

        private QuestionAndAnswer CurrentQuestionAndAnswer { get; set; }

        private int SelectedAnswerIndex { get; set; }

        public bool IsSelectedAnswerCorrect => CurrentQuestionAndAnswer != null && 
            SelectedAnswerIndex == CurrentQuestionAndAnswer.CorrectAnswerIndex;

        public void InitializeQuestion(QuestionAndAnswer questionAndAnswer)
        {
            CurrentQuestionAndAnswer = questionAndAnswer;
            SelectedAnswerIndex = DefaultAnswerIndex;

            _questionController.Refresh(questionAndAnswer.Question);
            _answerController.Refresh(questionAndAnswer.Answers);
        }

        public void SelectAnswer(int index)
        {
            SelectedAnswerIndex = index;
        }
    }
}