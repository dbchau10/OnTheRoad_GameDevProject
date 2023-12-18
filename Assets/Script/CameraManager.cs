using Cinemachine;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public CinemachineVirtualCamera finalCamera;
   
    void OnTriggerStay2D(Collider2D other)
    {
         finalCamera.Priority = 11;
    }
}
