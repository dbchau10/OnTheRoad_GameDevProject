using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriverBack : MonoBehaviour
{
    [SerializeField] float followSpeed = 35f;
    [SerializeField] float turningSpeed = 35f;
    [SerializeField] GameObject followObject;
    [SerializeField] Rigidbody2D rb, rb2;
    private Vector2 dir;
    private Quaternion prev;
    private bool movingBack = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = transform.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.LeftArrow))
        {

            //StartCoroutine(cr());
        }
        prev = transform.rotation;
        if (rb2.velocity.magnitude > 1f)
        dir = new Vector2(followObject.transform.position.x - transform.position.x, followObject.transform.position.y - transform.position.y);

        Debug.Log(dir);
        if (Input.GetKey(KeyCode.DownArrow)) movingBack = true;


        if (!movingBack)
        transform.up = Vector3.Slerp(transform.up, dir, Time.deltaTime * followSpeed);

        if (rb2.velocity.magnitude > 1f || !((Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.LeftArrow))))
        {
            transform.position = Vector2.Lerp(transform.position, followObject.transform.position, Time.deltaTime * followSpeed);
            Debug.Log("moveee");
        }

        if (Input.GetKey(KeyCode.UpArrow) && movingBack)
        {
            movingBack = false;
        }

        //rb.velocity = rb2.velocity;


        //transform.rotation = Quaternion.RotateTowards(prev, followObject.transform.rotation, 0.5f);        
    }

    //IEnumerator tr(Quaternion newRotation)
    //{
    //    float time = 20f;
    //    var orig = transform.rotation;
    //    Debug.Log(newRotation);
    //    while (time > 0f)
    //    {
    //        time -= Time.deltaTime;
    //        //Debug.Log(time);
    //        transform.rotation = Quaternion.Lerp(orig, newRotation, 0.5f);
    //        yield return null;
    //    }
    //}

    IEnumerator cr()
    {
        float time = 5f;
        while (time > 0f)
        {
            time -= Time.deltaTime;
            transform.up = Vector3.Slerp(transform.up, dir, Time.deltaTime * followSpeed);
            yield return null;
        }
    }
}
