using QuizBot.UIControllers.BaseClasses;
using TMPro;
using UnityEngine;

namespace QuizBot.UIControllers
{
    public class QuestionController : UIController<Question>
    {
        [SerializeField]
        private TMP_Text _questionText = null;

        public override void Refresh(Question data)
        {
            _questionText.text = data.QuestionText;
        }
    }
}