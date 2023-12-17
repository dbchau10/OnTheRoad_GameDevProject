using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class QuizManager : MonoBehaviour
{
    public List<QuestionAndAnswer> qna;
    public GameObject[] options;
    public int currentQuestion;
    public TMP_Text QuestionTxt;

    private void Start(){
        generateQuestion();
    }

    void SetAnswers(){
        for (int i= 0; i < options.Length; i++){
            options[i].transform.GetChild(0).GetComponent<TMP_Text>().text = qna[currentQuestion].Answers[i];
        }
    }
    void generateQuestion(){
        currentQuestion = Random.Range(0,qna.Count);
        QuestionTxt.text =  qna[currentQuestion].Question;

    }
}
