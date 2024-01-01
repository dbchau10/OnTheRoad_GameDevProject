using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AnswerScript : MonoBehaviour
{
    public bool isCorrect = false;
    public QuizManager quizManager;
    public UiManager uiManager;

    public GameObject ContinueBtn;
    public GameObject QuizTimer;
  
    Scene currentScene;
  void Start()
  {
         currentScene = SceneManager.GetActiveScene ();
  }
    public void Answer(){

      

		

		if (currentScene.name == "QuizTest") 
        // if (quizManager.QuizTest)
		{
            quizManager.DisableAnswer();
           
            Debug.Log("Hello");
            if (isCorrect){
                SetColor(Color.green);
                quizManager.correctQuestion++;
            }
            else {
                SetColor(Color.red);
            }

             QuizTimer.GetComponent<WarningTimer>().StopWarning();

              if (quizManager.numberQuestion + 1 < 10){  
              ContinueBtn.SetActive(true);
              }
        }
        else {
        if (isCorrect){
            Debug.Log("Correct Answer");
            StartCoroutine(AnswerResult(Color.green));
           
            
        
        }
        else {
               StartCoroutine(AnswerResult(Color.red));
        }
        }
      
    }

    public void AddTime(){
        uiManager.CountDownSeconds+=20;
        Debug.Log(uiManager.CountDownSeconds);
    }


    public void SetColor(Color colorButton){
          GetComponent<Image>().color = colorButton;
    }
     IEnumerator AnswerResult(Color colorButton)
    {
	
           SetColor(colorButton);
            yield return new WaitForSeconds(2);
            if (isCorrect){
            quizManager.correct();
            }
            else {
                quizManager.QuizSkip();
            }
            // ColorBlock colors = GetComponent<Button>().colors;
           SetColor(Color.white);
            AddTime();
    }

}
