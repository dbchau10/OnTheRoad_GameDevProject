using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinueQuizButton : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject QuizMarathon;

   public void HandleClick(){
   QuizMarathon.GetComponent<QuizManager>().HandleContinue();
   QuizMarathon.GetComponent<QuizManager>().DisableAnswer();
    gameObject.SetActive(false);
   }
}
