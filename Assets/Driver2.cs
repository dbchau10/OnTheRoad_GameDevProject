using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst;
using UnityEngine;

public class Driver2 : MonoBehaviour
{
    [SerializeField] float steerSpeed = 500f;
    [SerializeField] float moveSpeed = 10f;

    [SerializeField] float slowSpeed = 5f;
    [SerializeField] float boostSpeed = 30f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Rotate(0, 0, -steerAmount);
        transform.Translate(0,moveAmount, 0);

    }

    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "SpeedUp"){
            moveSpeed = boostSpeed;
        }
    }

   void OnCollisionEnter2D(Collision2D other)
    {
        moveSpeed = slowSpeed;
    }
}
