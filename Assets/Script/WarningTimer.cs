using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class WarningTimer : MonoBehaviour
{
  
    Scene currentScene;
    public Image uiFill;

    public int Duration = 10;

    private int remainingDuration;
    public GameObject QuizMarathon;

   
    public void Warning(){
        gameObject.SetActive(true);
         Being(Duration);
    }

    public void StopWarning(){
         gameObject.SetActive(false);
         StopCoroutine(UpdateTimer());
    }
    private void Being(int Second)
    {
        remainingDuration = Second;
        StartCoroutine(UpdateTimer());
    }

    private IEnumerator UpdateTimer()
    {
        while(remainingDuration >= 0)
        {
           
               
                uiFill.fillAmount = Mathf.InverseLerp(0, Duration, remainingDuration);
                remainingDuration--;
                yield return new WaitForSeconds(1f);
            
          
        }
        OnEnd();
    }

    private void OnEnd()
    {
        //End Time , if want Do something
        Debug.Log("End");
          gameObject.SetActive(false);

        //   currentScene = SceneManager.GetActiveScene();
        //   if (currentScene.name == "QuizTest"){
            if (QuizMarathon.GetComponent<QuizManager>().QuizTest){
            QuizMarathon.GetComponent<QuizManager>().TimeOut();
          }
    }
}
