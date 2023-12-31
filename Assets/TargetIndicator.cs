using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetIndicator : MonoBehaviour
{
    public GameObject target;
    public float offScreenThreshold = 10f;
    private Camera mainCamera;
    private bool isIndicatorActive = true;

    void Start()
    {
        mainCamera = Camera.main;
    }

    private void Update()
    {
        if(isIndicatorActive)
        {
            Vector3 targetDirection = target.transform.position - transform.position;
            float distanceToTarget = targetDirection.magnitude;

            if(distanceToTarget < offScreenThreshold)
            {
                gameObject.SetActive(false);
                isIndicatorActive = false;
            }
            else
            {
                Vector3 targetViewPortPosition = mainCamera.WorldToScreenPoint(target.transform.position);

                if (targetViewPortPosition.z > 0 && targetViewPortPosition.x > 0 && targetViewPortPosition.x < 1 && targetViewPortPosition.y > 0 && targetViewPortPosition.y < 1)
                {
                    gameObject.SetActive(false);
                }
                else
                {
                    gameObject.SetActive(true);
                    Vector3 screenEdge = mainCamera.ViewportToWorldPoint(new Vector3(Mathf.Clamp(targetViewPortPosition.x, 0.1f, 0.9f), Mathf.Clamp(targetViewPortPosition.y, 0.1f, 0.9f), mainCamera.nearClipPlane));
                    transform.position = new Vector3(screenEdge.x, screenEdge.y, 0);
                    Vector3 direction = target.transform.position - transform.position;
                    float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                    transform.rotation = Quaternion.Euler(0, 0, angle);
                }
            }
        }
    }


}
