using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneWayRoad : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
         Debug.Log("Enter one way road");
    }
}
