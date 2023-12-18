using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMeetTrafficLight : MonoBehaviour
{
   
   public GameObject TrafficLight;
   public GameObject WarningTimer;
   public bool checkOpenQuiz=false;

//    public bool checkSkip = false;
   void OnTriggerStay2D(Collider2D other)
   {
        if (TrafficLight.GetComponent<ChangeTrafficLightState>().currentLightState == "Red" && !checkOpenQuiz ){
            if (other.tag == "HeadCar"){
                FindObjectOfType<QuizManager>().QuizOpen();
                checkOpenQuiz = true;
            }
        }
       
   }

 
    void OnTriggerEnter2D(Collider2D other)
    {
         if (other.tag == "HeadCar"){
                WarningTimer.GetComponent<WarningTimer>().StopWarning();
               
            }
    }
  
   void OnTriggerExit2D(Collider2D other)
   {
        if (TrafficLight.GetComponent<ChangeTrafficLightState>().currentLightState == "Red" ){
            if (other.tag == "HeadCar"){
                WarningTimer.GetComponent<WarningTimer>().Warning();
               
            }
        }
   }
}
