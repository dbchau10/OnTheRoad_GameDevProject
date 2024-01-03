using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleTween : MonoBehaviour
{
   
    public GameObject QuizScene;
    public GameObject QuizMarathon;

    float timer;
    bool timerReached = false;
   public void OnEnable()
   {
         LeanTween.scale(gameObject, new Vector3(1,1,1), 0.5f).setDelay(1f).setEase(LeanTweenType.easeInOutElastic).setOnComplete(OnClose);
        //  if (!timerReached)
        //     timer += Time.unscaledDeltaTime;

        // if (!timerReached && timer > 2)
        // {
        //     DestroyMe();

        //     timerReached=true;
        // }
   }

    public void OnClose(){
        LeanTween.scale(gameObject, new Vector3(0,0,0), 0.5f ).setOnComplete(DestroyMe);
    }
   void DestroyMe(){
       QuizScene.SetActive(true);
       QuizMarathon.GetComponent<QuizManager>().QuizTest = true;
        
        gameObject.SetActive(false);
   }
}
