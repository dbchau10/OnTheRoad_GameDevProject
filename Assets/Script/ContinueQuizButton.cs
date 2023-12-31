using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinueQuizButton : MonoBehaviour
{
    // Start is called before the first frame update
    

   public void HandleClick(){
    FindObjectOfType<QuizManager>().HandleContinue();
    gameObject.SetActive(false);
   }
}
