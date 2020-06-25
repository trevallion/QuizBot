using QuizBot.Data;
using System.Collections.Generic;

namespace QuizBot.GameLogic.QuizProviders
{
    public class LocalQuizProvider : IQuizProvider
    {
        private LocalQuizQuestions LocalQuizQuestions { get; set; }

        public LocalQuizProvider(LocalQuizQuestions localQuizQuestions)
        {
            LocalQuizQuestions = localQuizQuestions;
        }

        public List<QuestionAndAnswer> GetQuizQuestions()
        {
            return LocalQuizQuestions.QuizQuestions;
        }
    }
}