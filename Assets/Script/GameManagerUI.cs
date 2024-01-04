using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManagerUI : MonoBehaviour
{
    public GameObject gameOverUI;
    public GameObject gameCompletedUI;
    public GameObject backgroundMusic;

    public AudioClip gameOverSound;
    public AudioClip gameCompletedSound;

    private bool gameOver = false;
    public bool gameDone {get {return gameOver;} }
    public void GameOver(){
        gameOverUI.SetActive(true);
        gameOver = true;
        backgroundMusic.SetActive(false);
        GetComponent<AudioSource>().PlayOneShot(gameOverSound);
    }

     public void GameCompleted(){
        gameCompletedUI.SetActive(true);
         gameOver = true;
        backgroundMusic.SetActive(false);
        GetComponent<AudioSource>().PlayOneShot(gameCompletedSound);
    }

    public void Restart() {
        gameOver = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        PlayerPrefs.SetString("hasCheckpoint", "");
        Time.timeScale = 1;
    }
    
}
