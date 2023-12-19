using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private float startTime;
    private float restSeconds;
    private int roundedRestSeconds;
    private float displaySeconds;
    private float displayMinutes;
    [SerializeField] int CountDownSeconds = 120;
    private float Timeleft;
    string timetext;

    public static Timer instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    void Start()
    {
        startTime = Time.deltaTime;
        Timeleft = restSeconds = displaySeconds = CountDownSeconds = 120;

    }


    public void OnGUI()
    {

        Timeleft = Time.time - startTime;

        restSeconds = CountDownSeconds - (Timeleft);

        roundedRestSeconds = Mathf.CeilToInt(restSeconds);
        displaySeconds = roundedRestSeconds % 60;
        displayMinutes = (roundedRestSeconds / 60) % 60;

        timetext = (displayMinutes.ToString() + ":");
        if (displaySeconds > 9)
        {
            timetext = timetext + displaySeconds.ToString();
        }
        else
        {
            timetext = timetext + "0" + displaySeconds.ToString();
        }
        GUI.Label(new Rect(650.0f, 0.0f, 100.0f, 75.0f), timetext);
    }
}
