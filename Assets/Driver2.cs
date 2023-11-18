using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Burst;
using UnityEngine;

public class Driver2 : MonoBehaviour
{
    [SerializeField] float steerSpeed = 15f;
    [SerializeField] float initMoveSpeed = 35f;
    [SerializeField] float moveSpeed = 35f;

    [SerializeField] float slowSpeed = 15f;
    [SerializeField] float boostSpeed = 30f;
    [SerializeField] ParticleSystem ps;
    [SerializeField] Rigidbody2D player;

    bool isMoving = false;
    private float _direction = 0;
    private string trueDirection = "";
    bool isPennalized = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        //transform.Rotate(0, 0, -steerAmount);
        //transform.Translate(0,moveAmount, 0);

        player.angularVelocity += -(Input.GetAxis("Horizontal") * steerSpeed);
        if ((Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow)) && isMoving)
        {
            isMoving = false;
            ps.Stop();
            //Debug.Log("Stop fuming");
        }
        if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.LeftArrow))
        {
            player.angularVelocity = 0;
        }
        if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow)) && !isMoving) isMoving = true;
        if (isMoving)
        {
            _direction = Mathf.Sign(Vector2.Dot(player.velocity, player.GetRelativeVector(Vector2.up)));
            player.AddRelativeForce(Vector2.up * Input.GetAxis("Vertical") * moveSpeed);
            player.AddRelativeForce(Vector2.right * player.velocity.magnitude * Input.GetAxis("Horizontal") / 2);
            if (!ps.isEmitting)
            {
                ps.Play();
                //Debug.Log("Emit FUmes" + Time.deltaTime);
            }
        }
    }

    public string getDirection()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow) && _direction < 0)
        {
            trueDirection = "d";
        }
        if(Input.GetKeyDown(KeyCode.DownArrow) && _direction > 0)
        {
            trueDirection = "u";
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) && _direction > 0)
        {
            trueDirection = "u";
        }

        if (Input.GetKeyDown(KeyCode.DownArrow) && _direction < 0)
        {
            trueDirection = "d";
        }


        return trueDirection;
    }

    public void penalize()
    { 
        Debug.Log("Minus time, show warning");
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "SpeedUp"){
            StartCoroutine(SpeedBoost(5f));
        }
    }

   void OnCollisionEnter2D(Collision2D other)
    {
        moveSpeed = slowSpeed;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        moveSpeed = initMoveSpeed;
    }

    private IEnumerator SpeedBoost(float waitTime)
    {
        moveSpeed = boostSpeed;
        yield return new WaitForSeconds(waitTime);
        moveSpeed = initMoveSpeed;
    }
}
