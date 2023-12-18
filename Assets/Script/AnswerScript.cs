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
            quizManager.correct();
            // GetComponent<Button>().colors.normalColor = Color.red;
            
        
        }
        else {
            Debug.Log("Wrong Answer");
        }

    }

    public void AddTime(){
        uiManager.CountDownSeconds+=20;
    }

}
