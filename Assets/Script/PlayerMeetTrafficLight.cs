using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMeetTrafficLight : MonoBehaviour
{
   
   public GameObject TrafficLight;
   void OnTriggerEnter2D(Collider2D other)
   {
        if (TrafficLight.GetComponent<ChangeTrafficLightState>().currentLightState == "Red"){
            if (other.tag == "HeadCar"){
                FindObjectOfType<QuizManager>().QuizOpen();
            }
        }
   }
}
