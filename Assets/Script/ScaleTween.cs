using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleTween : MonoBehaviour
{
   
    public GameObject QuizScene;
    public GameObject QuizMarathon;
   public void OnEnable()
   {
        // transform.localScale = new Vector3(0,0,0);
        LeanTween.scale(gameObject, new Vector3(1,1,1), 0.5f).setDelay(2f).setOnComplete(OnClose);
   }

    public void OnClose(){
        LeanTween.scale(gameObject, new Vector3(0,0,0), 0.5f ).setOnComplete(DestroyMe);
    }
   void DestroyMe(){
    Destroy(gameObject);
       QuizScene.SetActive(true);
         QuizMarathon.GetComponent<QuizManager>().QuizTest = true;
   }
}
