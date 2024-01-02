using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPlayQuiz : MonoBehaviour
{

    public GameObject ReviewTimeModal;

    bool timerReached = false;
    float timer = 0;
    void OnTriggerEnter2D(Collider2D other)
    {
        ReviewTimeModal.SetActive(true);
        
                 
                    Destroy(this); 
        
        //  if (!timerReached)
        //     timer += Time.unscaledDeltaTime;

        // if (!timerReached && timer > 2)
        // {
        //       Debug.Log("Done waiting");
                    
        //               Time.timeScale = 0f;
        

        //             QuizScene.SetActive(true);
        //             QuizMarathon.GetComponent<QuizManager>().QuizTest = true;
        //             Destroy(this); 
        //             timerReached = true;
        // }

      
    }
}
