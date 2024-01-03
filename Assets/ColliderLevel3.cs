using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderLevel3 : MonoBehaviour
{
    // Start is called before the first frame update
    bool firstEnter = false;

    public GameObject WarningTimer;
    public GameObject Snackbar;

    public void showWarning()
    {
        WarningTimer.GetComponent<WarningTimer>().Warning();
        var snackbar = Snackbar.GetComponent<MoveModal>();
        snackbar.content = "XE SỐ CHẠM VẠCH. TRỪ ĐIỂM!";
        snackbar.gameObject.SetActive(true);
    }

    public void closeWarning()
    {
        WarningTimer.GetComponent<WarningTimer>().StopWarning();
        var snackbar = Snackbar.GetComponent<MoveModal>();
        snackbar.gameObject.SetActive(false);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!firstEnter)
        {
            firstEnter = true;

            // cong 1 diem
            Debug.Log("cong 1 diem");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // tru 1 diem
        Debug.Log("tru 1 diem");
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
