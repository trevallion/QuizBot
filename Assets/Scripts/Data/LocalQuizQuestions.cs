using System.Collections.Generic;
using UnityEngine;

namespace QuizBot.Data
{
    [CreateAssetMenu(fileName = "LocalQuizQuestions", menuName = "ScriptableObjects/LocalQuizQuestions", order = 1)]
    public class LocalQuizQuestions : ScriptableObject
    {
        public List<QuestionAndAnswer> QuizQuestions;
    }
}