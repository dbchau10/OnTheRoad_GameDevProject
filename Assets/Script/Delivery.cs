using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Delivery : MonoBehaviour
{

    bool hasPackage;
    public bool isPennalize = false;
    public bool isFlicking = false;
    [SerializeField] float deleteTime = 0.5f;
    [SerializeField] Color32 hasPackageColor = new Color32(0,1,0,1);
    [SerializeField] Color32 noPackageColor = new Color32(1,1,1,1);
    Color32 lerpColor;
    int blinkSpeed = 1;

    [SerializeField] Rigidbody2D body;

    SpriteRenderer spriteRenderer;

    [SerializeField] Driver2 parent;

  
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        parent = transform.GetComponent<Driver2>();
        body = transform.GetComponent<Rigidbody2D>();
    }

    IEnumerator startFlicking()
    {
        //Debug.Log("flickering");
        if (!isFlicking)
        {
            isFlicking = true;
            while (isPennalize && isFlicking)
            {
                lerpColor = Color.Lerp(Color.black, Color.white, Mathf.PingPong(Time.time * blinkSpeed, 1.0f));
                spriteRenderer.color = lerpColor;
                yield return new WaitForSeconds(0.1f);
            }
            isFlicking = false;
        }
    }

    private void Update()
    {
        if (body.velocity.magnitude == 0)
        {
            //Debug.Log("car stopped");
            isPennalize = isFlicking = false;
            spriteRenderer.color = noPackageColor;
            return;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Ouch!");
        if (other.collider.tag == "SchoolGirl")
        {
            StudentController sc = other.gameObject.GetComponent<StudentController>();
            sc.showWarning();
            parent.penalize(-1);
            StartCoroutine(CountDownToDisapear(sc));
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "OneWayRoad" )
        {
            isPennalize = false;
            spriteRenderer.color = noPackageColor;
            collision.gameObject.GetComponent<OneWayRoad>().closeWarning();
        }
        else if(collision.tag == "SpeedLimitedRoad")
        {
            isPennalize = false;
            spriteRenderer.color = noPackageColor;
            collision.gameObject.GetComponent<SpeedLimitedRoad>().closeWarning();
        }
        else if (collision.tag == "Level3")
        {
            isPennalize = false;
            spriteRenderer.color = noPackageColor;
            collision.gameObject.GetComponent<ColliderLevel3>().closeWarning();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Level3")
        {
            var road = collision.transform.GetComponent<ColliderLevel3>();
            isPennalize = true;
            // Debug.Log("One way road");
            // parent.penalize(-1);
            // road.showWarning();
            if (isPennalize && !isFlicking)
                StartCoroutine(startFlicking());
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Package") {
           //  Debug.Log("Package Picked Up!");
            Destroy(other.gameObject, deleteTime);
            parent.addBonusTime(8);
        }

        else if (other.tag == "OneWayRoad")
        {
            OneWayRoad road = other.transform.GetComponent<OneWayRoad>();

            //Debug.Log("Road direction" + road.getDirection());
            //Debug.Log("moto direction" + parent.getDirection());

            var r = road.getDirection();

            if (r.x < 0)
            {
                if (body.velocity.x <= 0)
                {
                    isPennalize = isFlicking = false;
                    spriteRenderer.color = noPackageColor;
                    road.closeWarning();
                }
                else if (body.velocity.x > 0)
                {
                    isPennalize = true;
                    // Debug.Log("One way road");
                    parent.penalize(-10);
                    road.showWarning();
                }
            }
            else if (r.x > 0)
            {
                if (body.velocity.x >= 0)
                {
                    isPennalize = isFlicking = false;
                    spriteRenderer.color = noPackageColor;
                    road.closeWarning();
                }
                else if (body.velocity.x < 0)
                {
                    isPennalize = true;
                    // Debug.Log("One way road");
                    parent.penalize(-10);
                    road.showWarning();
                }
            }
            if (r.y < 0)
            {
                if (body.velocity.y <= 0)
                {
                    isPennalize = isFlicking = false;
                    spriteRenderer.color = noPackageColor;
                    road.closeWarning();
                }
                else if (body.velocity.y > 0)
                {
                    isPennalize = true;
                    // Debug.Log("One way road");
                    parent.penalize(-10);
                    road.showWarning();
                }
            }
            else if (r.y > 0)
            {
                if (body.velocity.y >= 0)
                {
                    isPennalize = isFlicking = false;
                    spriteRenderer.color = noPackageColor;
                    road.closeWarning();
                }
                else if (body.velocity.y < 0)
                {
                    isPennalize = true;
                    // Debug.Log("One way road");
                    parent.penalize(-10);
                    road.showWarning();
                    
                }
            }


            if (isPennalize && !isFlicking)
                StartCoroutine(startFlicking());
        } 

        else if(other.tag == "SpeedLimitedRoad")
        {
            SpeedLimitedRoad road = other.gameObject.GetComponent<SpeedLimitedRoad>();
            if(road.getSpeed() < Mathf.Abs(body.velocity.x) || road.getSpeed() < Mathf.Abs(body.velocity.y))
            {
                isPennalize = false;
                spriteRenderer.color = noPackageColor;
                road.closeWarning();
            }
            else
            {
                // Debug.Log("Exceed current speed limit: " + road.getSpeed());
                parent.penalize(-4);
                isPennalize = true;
                road.showWarning();
            }

            if (isPennalize && !isFlicking)
                StartCoroutine(startFlicking());

        }
    }

    IEnumerator CountDownToDisapear(StudentController sc)
    {
        var penaltyTime = 6.0f;
        while(penaltyTime > 0)
        {
            penaltyTime -= Time.deltaTime;
            yield return new WaitForSeconds(6.0f);
        }
        sc.closeWarning();
    }
}
