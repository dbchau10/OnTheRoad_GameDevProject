using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{

    // this camera's position should be at the same as the car's position
   [SerializeField] GameObject thingToFollow;
    void LateUpdate()
    {
         Vector3 targetPosition = thingToFollow.transform.position + new Vector3(0,0,-10);
          transform.position = new Vector3(Mathf.Clamp(targetPosition.x,-1.01f,5.99f), Mathf.Clamp(targetPosition.y,-3f,3.96f), targetPosition.z);
    }
}
