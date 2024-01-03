using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPlayQuiz : MonoBehaviour
{

    public GameObject ReviewTimeModal;
    public GameObject Player;

    public List<GameObject> QuizCollider;

    bool timerReached = false;
    float timer = 0;
    void OnTriggerEnter2D(Collider2D other)
    {   
          if (other.tag == "HeadCar"){
        Player.SetActive(false);
        ReviewTimeModal.SetActive(true);
         
                    for (int i = QuizCollider.Count-1; i >= 0; i --){
                        Destroy(QuizCollider[i]);
                        QuizCollider.RemoveAt(i);
                    }
                    Destroy(this); 
          }
        
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
