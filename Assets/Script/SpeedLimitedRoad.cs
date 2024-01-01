using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedLimitedRoad : MonoBehaviour
{
    [SerializeField] float limitedSpeed = 30f;

    public GameObject WarningTimer;
    public GameObject Snackbar;

    internal float getSpeed()
    {
        return limitedSpeed;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        
    }

    public void showWarning()
    {
        WarningTimer.GetComponent<WarningTimer>().Warning();
        var snackbar = Snackbar.GetComponent<MoveModal>();
        snackbar.content = "Bạn đang đi quá tốc độ, vui lòng đi chậm lại!!";
        snackbar.gameObject.SetActive(true);
    }

    public void closeWarning()
    {
        WarningTimer.GetComponent<WarningTimer>().StopWarning();
        var snackbar = Snackbar.GetComponent<MoveModal>();
        snackbar.gameObject.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
