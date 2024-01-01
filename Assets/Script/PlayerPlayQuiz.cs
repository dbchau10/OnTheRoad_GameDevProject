using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPlayQuiz : MonoBehaviour
{
    public GameObject QuizScene;
    public GameObject QuizMarathon;
    void OnTriggerEnter2D(Collider2D other)
    {
        Time.timeScale = 0f;
        // SceneManager.LoadScene("QuizTest");

        QuizScene.SetActive(true);
        QuizMarathon.GetComponent<QuizManager>().QuizTest = true;
        Destroy(this);
    }
}
