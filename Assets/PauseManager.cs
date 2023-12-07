using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public bool gameIsPaused { get; private set; } = false;

    public static PauseManager instance;

    public GameObject pauseMenu;    

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void Update()
    {
        
    }

    public void QuitLevel()
    {
        SceneManager.LoadScene("MainMenuScene");

        //Lưu lại thông tin
    }

    public void PauseGame()
    {
        Debug.Log("Pause menu is being called");
        if (gameIsPaused)
        {
            Time.timeScale = 0f;
            pauseMenu.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            pauseMenu.SetActive(false);
        }
        gameIsPaused = !gameIsPaused;
    }
}
