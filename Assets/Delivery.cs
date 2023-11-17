using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Delivery : MonoBehaviour
{

    bool hasPackage;
    [SerializeField] float deleteTime = 0.5f;
    [SerializeField] Color32 hasPackageColor = new Color32(0,1,0,1);
    [SerializeField] Color32 noPackageColor = new Color32(1,1,1,1);


    SpriteRenderer spriteRenderer;

  
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Ouch!");
    }

    void OnTriggerEnter2D(Collider2D other)
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
            Debug.Log("One way road");
        }
    }
}
