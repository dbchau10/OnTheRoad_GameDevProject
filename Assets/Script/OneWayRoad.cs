using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.Collections;
using UnityEngine;

public class OneWayRoad : MonoBehaviour
{

    public GameObject WarningTimer;
    public GameObject Snackbar;

    // up (y 1), down (y -1), right (x 1), left (x -1) 
    [SerializeField] int xDirection = 1;
    [SerializeField] int yDirection = 0;

    Driver2 moto;

    // Start is called before the first frame update
    void Start()
    {
        moto = GetComponent<Driver2>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        
    }

    public void showWarning()
    {
        WarningTimer.GetComponent<WarningTimer>().Warning();
        var snackbar = Snackbar.GetComponent<MoveModal>();
        snackbar.content = "Bạn đang đi ngược chiều, nên đổi chiều ngược lại.";
        snackbar.gameObject.SetActive(true);
    }

    public void closeWarning()
    {
        WarningTimer.GetComponent<WarningTimer>().StopWarning();
        var snackbar = Snackbar.GetComponent<MoveModal>();
        snackbar.gameObject.SetActive(false);
    }

    internal (int x, int y) getDirection()
    {
        if (xDirection == 0) return (0, yDirection);
        if (yDirection == 0) return (0, xDirection);

        return (0, 0);
    }
}
