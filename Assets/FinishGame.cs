using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishGame : MonoBehaviour
{
     private UiManager uiManager;
     Scene currentScene;
      private void Awake()
    {
        uiManager = GameObject.Find("Canvas").GetComponent<UiManager>();
        currentScene = SceneManager.GetActiveScene();
    }
   void OnTriggerEnter2D(Collider2D other)
   {
       if (other.tag == "HeadCar"){

        if (currentScene.name != "SampleMapLevel3"){
        if (uiManager.getCurrentScore() >= 20){
        FindObjectOfType<GameManagerUI>().GameCompleted();
        }
        else {
            FindObjectOfType<GameManagerUI>().GameOver();
        }
        }
        else {
              if (uiManager.getCurrentScore() > -5){
        FindObjectOfType<GameManagerUI>().GameCompleted();
        }
        else {
            FindObjectOfType<GameManagerUI>().GameOver();
        }
        }
       }
   }
}
