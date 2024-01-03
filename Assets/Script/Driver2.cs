using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Burst;
using Unity.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Driver2 : MonoBehaviour
{
    [SerializeField] float steerSpeed = 15f;
    [SerializeField] float initMoveSpeed = 35f;
    [SerializeField] float moveSpeed = 35f;

    [SerializeField] float slowSpeed = 5f;
    [SerializeField] float boostSpeed = 100f;
    [SerializeField] ParticleSystem ps, psBrake;
    [SerializeField] Rigidbody2D player;
    [SerializeField] GameObject back;
    [SerializeField] GameObject frontLight;
    [SerializeField] GameObject backLight;

    bool turnOnLight = true;

    [SerializeField] TextMeshProUGUI CoinCounts;

    public int coins;
    bool isMoving = false;
    private float _direction = 0;
    private string trueDirection = "";
    private Quaternion prevRotation;
    private int currentScore = 0;
    // Start is called before the first frame update
    public CoinCollection coinCollects;
    private UiManager uiManager;
    AudioManager audioManager;
    System.Random rand = new();

    private void Awake()
    {
        uiManager = GameObject.Find("Canvas").GetComponent<UiManager>();
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    void Start()
    {

        player = transform.GetComponent<Rigidbody2D>();
        StartCoroutine(LightCooldown());
    }

    IEnumerator LightCooldown()
    {
        while(isActiveAndEnabled)
        {
            yield return new WaitForSeconds(rand.Next(1, 7));
            turnOnLight = !turnOnLight;
        }
    }

    // Update is called once per frame
    void Update()
    {
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed * 100 * Time.deltaTime;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        //transform.Rotate(0, 0, -steerAmount);
        //transform.Translate(0,moveAmount, 0);
        //Debug.Log(Quaternion.Angle(transform.rotation, back.transform.rotation));


        if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S))
        {
            psBrake.Play();
        }

        if ((Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S)) && isMoving)
        {
            isMoving = false;
            ps.Stop();
            //Debug.Log("Stop fuming");
        }
        if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.A))
        {
            player.angularVelocity = 0;
            steerAmount = 0;
        }
        if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S)) && !isMoving) isMoving = true;
        if (isMoving)
        {
            float mSpeed = moveSpeed;
            if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
            {
                backLight.SetActive(true);
                if (player.velocity.magnitude >= 1f) mSpeed = moveSpeed / 100f;
                else mSpeed = 0;
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

        frontLight.SetActive(turnOnLight);
        backLight.SetActive(turnOnLight);

        if (Input.GetKeyDown(KeyCode.Space) && !turnOnLight) {
            turnOnLight = true;
        }

        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.A))
        {
            //Debug.Log("prep" + prevRotation);
            prevRotation = transform.rotation;
        }

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.A))
        {
            Debug.Log(Mathf.DeltaAngle(transform.eulerAngles.z, prevRotation.eulerAngles.z));
            if (Mathf.Abs(Mathf.DeltaAngle(transform.eulerAngles.z, prevRotation.eulerAngles.z)) > 20f)
            {
                if (player.velocity.magnitude < 1f)
                steerAmount = 0;
            }
        }    

        player.angularVelocity += -(steerAmount);

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

    public void penalize(int amount)
    {
        currentScore = Mathf.Clamp(currentScore + amount, 0, 999999);
        Debug.Log("Minus time, show warning");
        uiManager.changeScore(currentScore);
    }

    public void addBonusTime(int amount)
    {
        Debug.Log("Bonus time");
        uiManager.AdjustTimeLeft(amount);
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "SpeedUp"){
            audioManager.PlaySFX(audioManager.speedup);
            StartCoroutine(SpeedBoost(5f));
            Destroy(other.gameObject);
        }
        else if (other.tag == "Coin"){
            audioManager.PlaySFX(audioManager.coinpickup);
            coins++;
            currentScore++;
            uiManager.changeScore(currentScore);
            // coinCollects.StartCoinMove(other.transform.position);
            CoinCounts.GetComponent<TextMeshProUGUI>().text = coins.ToString();
            Destroy(other.gameObject);
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
