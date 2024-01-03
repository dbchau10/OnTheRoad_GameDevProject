using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StudentController : MonoBehaviour
{
    public float speed = 1.5f;
    public bool vertical;
    Rigidbody2D rigidbody2D_;
    public float changeTime = 3f;
    float timer;
    public int direction = -1;

    public GameObject TrafficLight;
    Animator animator;

    public GameObject WarningTimer;
    public GameObject Snackbar;


    void Awake() {
         rigidbody2D_ = GetComponent<Rigidbody2D>();
          animator = GetComponent<Animator>();
       
    }
    void Start() {
       
        timer = changeTime;
        // healthBar.UpdateHealthBar(currentHealth, maxHealth);
       
    }

    public void showWarning()
    {
        WarningTimer.GetComponent<WarningTimer>().Warning();
        var snackbar = Snackbar.GetComponent<MoveModal>();
        snackbar.content = "Bạn mới tông người đi đường!!! Bạn bị phạt điểm";
        snackbar.gameObject.SetActive(true);
    }

    public void closeWarning()
    {
        WarningTimer.GetComponent<WarningTimer>().StopWarning();
        var snackbar = Snackbar.GetComponent<MoveModal>();
        snackbar.gameObject.SetActive(false);
    }



    void Update() {

        if (TrafficLight.GetComponent<ChangeTrafficLightState>().currentLightState == "Red"){
             timer -= Time.deltaTime;
        if (timer < 0) {
            direction = -direction; 
            timer = changeTime;
        }

        if (vertical)
        {
            animator.SetFloat("Move X", 0); 
            animator.SetFloat("Move Y", direction);
        }
        else
        {
        animator.SetFloat("Move Y", 0); 
        animator.SetFloat("Move X", direction);
        }
        }
        else return;
       
    }
    void FixedUpdate() {

         if (TrafficLight.GetComponent<ChangeTrafficLightState>().currentLightState == "Red"){
      
        Vector2 position = rigidbody2D_.position;
        if (vertical) {
            position.y = position.y + Time.deltaTime * speed * direction;
        }
        else {
            position.x = position.x + Time.deltaTime * speed * direction;
        }
        rigidbody2D_.MovePosition(position);
         }
         else return;
    }

   
}
