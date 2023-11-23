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

    [SerializeField] float slowSpeed = 5f;
    [SerializeField] float boostSpeed = 30f;
    [SerializeField] ParticleSystem ps, psBrake;
    [SerializeField] Rigidbody2D player;
    [SerializeField] GameObject back;

    bool isMoving = false;
    private float _direction = 0;
    private string trueDirection = "";
    bool isPennalized = false;
    private float prevRotation;
    // Start is called before the first frame update
    void Start()
    {
        player = transform.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        //transform.Rotate(0, 0, -steerAmount);
        //transform.Translate(0,moveAmount, 0);
        //Debug.Log(Quaternion.Angle(transform.rotation, back.transform.rotation));


        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            psBrake.Play();
        }

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
            float mSpeed = moveSpeed;
            if (Input.GetKey(KeyCode.DownArrow))
            {
                mSpeed = moveSpeed / 100f;
            }
            _direction = Mathf.Sign(Vector2.Dot(player.velocity, player.GetRelativeVector(Vector2.up)));
            player.AddRelativeForce(Vector2.up * Input.GetAxis("Vertical") * mSpeed);
            player.AddRelativeForce(Vector2.right * player.velocity.magnitude * Input.GetAxis("Horizontal") / 2);
            if (!ps.isEmitting)
            {
                ps.Play();
                //Debug.Log("Emit FUmes" + Time.deltaTime);
            }
        }

        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            prevRotation = transform.rotation.z;
            Debug.Log("prep" + prevRotation);
        }

        player.angularVelocity += -(Input.GetAxis("Horizontal") * steerSpeed);

        //if (player.transform.rotation.z > prevRotation + 25)
        //{
        //    transform.rotation = Quaternion.AngleAxis(360-prevRotation, new Vector3(0, 0, prevRotation + 25));
        //    Debug.Log("45");
        //}


        //if (player.transform.rotation.z < prevRotation - 25)
        //{
        //    transform.rotation = Quaternion.AngleAxis(prevRotation - 360, new Vector3(0, 0, prevRotation - 25));
        //    Debug.Log("-45");
        //}


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
