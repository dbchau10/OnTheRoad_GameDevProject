using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{

    // this camera's position should be at the same as the car's position
   [SerializeField] GameObject thingToFollow;
    void LateUpdate()
    {
          var targetPosition = thingToFollow.transform.position + new Vector3(0,0,-10);
          transform.position = new Vector3(Mathf.Clamp(targetPosition.x,-27.4f,356f), Mathf.Clamp(targetPosition.y,-0.5f,158f), targetPosition.z);
    }
}
