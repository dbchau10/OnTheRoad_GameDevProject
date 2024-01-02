using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizTransition : MonoBehaviour


{  
    
  
    bool hasRun = false;
    public void OnEnable()
   {
       if (!hasRun){
        LeanTween.moveLocalX(gameObject, 0f, 0.5f);
        hasRun = true;
       };
   }

   
   public void OnDisable()
   {
       if (hasRun){

         LeanTween.moveLocalX(gameObject, -1918f, 1f);
         hasRun = false;
       }
   }
}
