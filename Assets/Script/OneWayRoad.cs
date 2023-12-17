using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class OneWayRoad : MonoBehaviour
{
    // up (u), down (d), right (r), left (l) 
    [SerializeField] int xDirection = 1;
    [SerializeField] int yDirection = 0;

    Driver2 moto;

    // Start is called before the first frame update
    void Start()
    {
        moto = GetComponent<Driver2>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision == moto)
        {
        }
    }

    internal int getDirection()
    {
        if (xDirection == 0) return yDirection;
        if (yDirection == 0) return xDirection;

        return -1;
    }
}
