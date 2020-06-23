using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuizBot.Data
{
    [System.Serializable]
    public class Answer
    {
        public string AnswerText;
    }

    [System.Serializable]
    public class Question
    {
        public string QuestionText;
    }

    [System.Serializable]
    public class QuestionAndAnswer
    {
        public string Question;
        public List<string> Answers;
        public int CorrectAnswerIndex;
        public int ScoreValue;
        public float TimerDuration;
    }
}