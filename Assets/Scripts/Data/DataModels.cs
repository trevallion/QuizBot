using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Answer
{
    public string AnswerText;
}

public class Question
{
    public string QuestionText;
}

public class QuestionAndAnswer
{
    public Question Question;
    public List<Answer> Answers;
    public int ScoreValue;
    public float TimerDuration;
}