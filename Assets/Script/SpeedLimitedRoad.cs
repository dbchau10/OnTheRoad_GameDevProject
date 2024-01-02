using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedLimitedRoad : MonoBehaviour
{
    [SerializeField] float limitedSpeed = 30f;

    internal float getSpeed()
    {
        return limitedSpeed;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
