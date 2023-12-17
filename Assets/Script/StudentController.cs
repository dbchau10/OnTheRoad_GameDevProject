using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StudentController : MonoBehaviour
{
     public float speed = 1.5f;
    public bool vertical;
    Rigidbody2D rigidbody2D_;
    public float changeTime = 3.0f;
    float timer;
    int direction = 1;

    public GameObject TrafficLight;
    Animator animator;
  

    void Awake() {
         rigidbody2D_ = GetComponent<Rigidbody2D>();
          animator = GetComponent<Animator>();
       
    }
    void Start() {
       
        timer = changeTime;
        // healthBar.UpdateHealthBar(currentHealth, maxHealth);
       
    }

       public enum LightState
    {
        Red,
        Yellow,
        Green
    }
    void Update() {

        if (FindObjectOfType<ChangeTrafficLightState>().trafficLightState == LightState.Red){

        }
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
    void FixedUpdate() {
      
        Vector2 position = rigidbody2D_.position;
        if (vertical) {
            position.y = position.y + Time.deltaTime * speed * direction;
        }
        else {
            position.x = position.x + Time.deltaTime * speed * direction;
        }
        rigidbody2D_.MovePosition(position);
    }

   
}
