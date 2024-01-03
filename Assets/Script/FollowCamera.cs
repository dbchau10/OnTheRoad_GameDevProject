using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FollowCamera : MonoBehaviour
{

    // this camera's position should be at the same as the car's position
   [SerializeField] GameObject thingToFollow;

   Scene currentScene;
 
   void Start()
   {
    currentScene = SceneManager.GetActiveScene();
       
   }
    void LateUpdate()
    {
          var targetPosition = thingToFollow.transform.position + new Vector3(0,0,-10);

            if (currentScene.name == "SampleMap"){
          transform.position = new Vector3(Mathf.Clamp(targetPosition.x,-27.4f,356f), Mathf.Clamp(targetPosition.y,-0.5f,158f), targetPosition.z);
            }
            else if (currentScene.name == "SampleMapLevel2"){
                
            }
            else if (currentScene.name == "SampleMapLevel3"){


               Debug.Log("Scene3");
                  transform.position = new Vector3(Mathf.Clamp(targetPosition.x,6f,360f), Mathf.Clamp(targetPosition.y,-91f,127.1f), targetPosition.z);
            }
    }
}
