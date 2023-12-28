using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class QuestionAndAnswer
{
    public string Question;
    public string[] Answers;
    public int CorrectAnswer;
}


[System.Serializable]
public class QuestionAndAnswerList
{
    //employees is case sensitive and must match the string "employees" in the JSON.
    public QuestionAndAnswer[] questions;
}
