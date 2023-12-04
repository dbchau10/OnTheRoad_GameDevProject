using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Delivery : MonoBehaviour
{

    bool hasPackage;
    bool isPennalize;
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
        Debug.Log("flickering");
         lerpColor = Color.Lerp(Color.black, Color.white, Mathf.PingPong(Time.time * blinkSpeed, 1.0f));
         spriteRenderer.color = lerpColor;
         yield return new WaitForSeconds(0.1f);
    }

    private void Update()
    {
        if (Mathf.Abs(body.velocity.y) <= 0.5 && Mathf.Abs(body.velocity.x) <= 0.5)
        {
            spriteRenderer.color = noPackageColor;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Ouch!");
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "OneWayRoad" || collision.tag == "SpeedLimitedRoad")
        {
            isPennalize = false;
            spriteRenderer.color = noPackageColor;
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Package" && !hasPackage){
            Debug.Log("Package Picked Up!");
            hasPackage = true;
            Destroy(other.gameObject, deleteTime);
            spriteRenderer.color = hasPackageColor;
        }
        
        if (other.tag == "Customer" && hasPackage){
            Debug.Log("Package Deliveried Successfully!");
            hasPackage = false;
            spriteRenderer.color = noPackageColor;
        }

        if(other.tag == "OneWayRoad")
        {
            OneWayRoad road = other.transform.GetComponent<OneWayRoad>();

            Debug.Log("Road direction" + road.getDirection());
            Debug.Log("moto direction" + parent.getDirection());

            if (road.getDirection() < 0){
                if(body.velocity.y < 0 || body.velocity.x < 0)
                {
                    isPennalize = false;
                    spriteRenderer.color = noPackageColor;
                }
                else
                {
                    isPennalize = true;
                    Debug.Log("One way road");
                    parent.penalize();
                }
            }
            else
            {
                if (body.velocity.y > 0 || body.velocity.x > 0)
                {
                    isPennalize = false;
                    spriteRenderer.color = noPackageColor;
                }
                else
                {
                    isPennalize = true;
                    Debug.Log("One way road");
                    parent.penalize();
                }
            }
            
            if(isPennalize)
                StartCoroutine(startFlicking()); 
        }

        if(other.tag == "SpeedLimitedRoad")
        {
            SpeedLimitedRoad road = other.gameObject.GetComponent<SpeedLimitedRoad>();
            if(road.getSpeed() < Mathf.Abs(body.velocity.x) || road.getSpeed() < Mathf.Abs(body.velocity.y))
            {
                isPennalize = false;
                spriteRenderer.color = noPackageColor;
            }
            else
            {
                Debug.Log("Exceed current speed limit: " + road.getSpeed());
                parent.penalize();
                isPennalize = true;
            }

            if (isPennalize)
                StartCoroutine(startFlicking());

        }
    }
}
