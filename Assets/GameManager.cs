using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //Timer.instance.OnGUI();
    }


    // Update is called once per frame
    void Update()
    {
        if (!PauseManager.instance.gameIsPaused)
        {
            PauseManager.instance.PauseGame();
        }
        else
        {
            PauseManager.instance.PauseGame();
        }
    }
}
