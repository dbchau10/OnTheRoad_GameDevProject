using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMeetTrafficLight : MonoBehaviour
{
   
   public GameObject TrafficLight;

//    public bool checkSkip = false;
   void OnTriggerStay2D(Collider2D other)
   {
        if (TrafficLight.GetComponent<ChangeTrafficLightState>().currentLightState == "Red" ){
            if (other.tag == "HeadCar"){
                FindObjectOfType<QuizManager>().QuizOpen();
            }
        }
   }
}
