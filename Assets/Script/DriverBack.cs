using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DriverBack : MonoBehaviour
{
    [SerializeField] float followSpeed = 35f;
    [SerializeField] GameObject followObject;
    [SerializeField] Rigidbody2D rb, rb2;
    private Vector2 dir;
    private Quaternion prev, qr;
    private bool isMovingBack = false;
    private bool isTurning = false;
    SpriteRenderer sp, sp2;
    // Start is called before the first frame update
    void Start()
    {
        rb = transform.GetComponent<Rigidbody2D>();
        sp = GetComponent<SpriteRenderer>();
        sp2 = rb2.gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        sp.color = sp2.color;
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.LeftArrow))
        {

            isTurning = true;
        }

        //if (transform)

        if (Input.GetKey(KeyCode.DownArrow)) isMovingBack = true;

        if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.LeftArrow))
        {

            isTurning = false;
        }

        if (true)
        {
            transform.position = Vector2.Lerp(transform.position, followObject.transform.position, Time.deltaTime * followSpeed);
            //Debug.Log("moveee");
        }

        prev = transform.rotation;
        dir = new Vector2(followObject.transform.position.x - transform.position.x, followObject.transform.position.y - transform.position.y);

        //if (!isMovingBack)
        //    transform.up = Vector3.Slerp(transform.up, dir, Time.deltaTime * followSpeed);

        if ((transform.rotation.z != rb2.transform.rotation.z && !isTurning && rb2.velocity.magnitude > 1f) || (Mathf.Abs(Mathf.DeltaAngle(transform.eulerAngles.z, rb2.transform.rotation.eulerAngles.z)) > 20f))
        {
            isTurning = true;
            //transform.Rotate(transform.forward, transform.rotation.z < rb2.transform.rotation.z ? rb2.transform.rotation.z - transform.rotation.z : transform.rotation.z - rb2.transform.rotation.z);
            qr = Quaternion.Euler(new Vector3(transform.localEulerAngles.x, transform.localEulerAngles.y, rb2.transform.localEulerAngles.z));
        }

        //Debug.Log(transform.rotation);

        if (isTurning) transform.rotation = Quaternion.Lerp(transform.rotation, qr, 0.13f);

        if (transform.rotation.z == rb2.transform.rotation.z) isTurning = false;

        //Debug.Log(dir);

        if (Input.GetKey(KeyCode.UpArrow))
        {
            isTurning = false;
            if (isMovingBack) isMovingBack = false;
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

    //IEnumerator cr()
    //{
    //    float time = 5f;
    //    while (time > 0f)
    //    {
    //        time -= Time.deltaTime;
    //        transform.up = Vector3.Slerp(transform.up, dir, Time.deltaTime * followSpeed);
    //        yield return null;
    //    }
    //}
}
