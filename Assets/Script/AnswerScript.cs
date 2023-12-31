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
  
    Scene currentScene;
  void Start()
  {
         currentScene = SceneManager.GetActiveScene ();
  }
    public void Answer(){

      

		

		if (currentScene.name == "QuizTest") 
		{
            ContinueBtn.SetActive(true);
            Debug.Log("Hello");
            if (isCorrect){
                SetColor(Color.green);
            }
            else {
                SetColor(Color.red);
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
