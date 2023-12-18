using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerScript : MonoBehaviour
{
    public bool isCorrect = false;
    public QuizManager quizManager;
    public UiManager uiManager;

  
    public void Answer(){
        if (isCorrect){
            Debug.Log("Correct Answer");
            StartCoroutine(AnswerResult(Color.green));
           
            
        
        }
        else {
               StartCoroutine(AnswerResult(Color.red));
        }

    }

    public void AddTime(){
        uiManager.CountDownSeconds+=20;
        Debug.Log(uiManager.CountDownSeconds);
    }

     IEnumerator AnswerResult(Color colorButton)
    {
	
            GetComponent<Image>().color = colorButton;
            yield return new WaitForSeconds(2);
            if (isCorrect){
            quizManager.correct();
            }
            else {
                quizManager.QuizSkip();
            }
            // ColorBlock colors = GetComponent<Button>().colors;
            GetComponent<Image>().color = Color.white;
            AddTime();
    }

}
