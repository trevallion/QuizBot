using QuizBot.Data;
using System.Collections.Generic;

namespace QuizBot.GameLogic.QuizProviders
{
    public interface IQuizProvider
    {
        List<QuestionAndAnswer> GetQuizQuestions();
    }
}