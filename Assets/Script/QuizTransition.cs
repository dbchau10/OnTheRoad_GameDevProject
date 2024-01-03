using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizTransition : MonoBehaviour


{  
    
  
    bool hasRun = false;
    bool pause = false;
    public void OnEnable()
   {
    //    if (!hasRun){
        pause = true;
        LeanTween.moveLocalX(gameObject, 0f, 0.5f).setEase(LeanTweenType.easeInOutCirc).setDelay(0.5f).setOnComplete(OnPause);
        //   Time.timeScale = 0f;
    //     hasRun = true;
    //    };
   }


   void OnPause(){
    if (pause){
    Time.timeScale = 0f;
    }
    else {
        Time.timeScale = 1;
        //    gameObject.SetActive(false);
    }
   }

   
   public void CloseQuiz()
   {
    //    if (hasRun){
         pause = false;
         LeanTween.moveLocalX(gameObject, -1918f, 1f).setEase(LeanTweenType.easeInOutCirc).setDelay(0.5f).setOnComplete(OnPause);
     
    //      hasRun = false;
    //    }
   }
}
