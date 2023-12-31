using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AnswerScript : MonoBehaviour
{
    public bool isCorrect = false;
    public QuizManager quizManager;
    public UiManager uiManager;
    AudioManager audioManager;

    public GameObject ContinueBtn;
    public GameObject QuizTimer;

    Scene currentScene;
    void Start()
    {
        currentScene = SceneManager.GetActiveScene();
    }

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    public void Answer()
    {
        if (quizManager.QuizTest)
        {
            quizManager.DisableAnswer();

            if (isCorrect)
            {
                SetColor(Color.green);
                quizManager.correctQuestion++;
                quizManager.finalScore++;
            }
            else
            {
                SetColor(Color.red);
            }

            QuizTimer.GetComponent<WarningTimer>().StopWarning();

            if (quizManager.numberQuestion + 1 < 10)
            {
                ContinueBtn.SetActive(true);
            }
        }
        else
        {
            if (isCorrect)
            {
                audioManager.PlaySFX(audioManager.rightanswer);
                Debug.Log("Correct Answer");
                StartCoroutine(AnswerResult(Color.green));
            }
            else
            {
                audioManager.PlaySFX(audioManager.wronganswer);
                StartCoroutine(AnswerResult(Color.red));
            }
        }

    }

    public void AddTime()
    {
        uiManager.CountDownSeconds += 20;
    }

    public void SetColor(Color colorButton)
    {
        GetComponent<Image>().color = colorButton;
    }

    IEnumerator AnswerResult(Color colorButton)
    {

        SetColor(colorButton);
        yield
        return new WaitForSeconds(2);
        if (isCorrect)
        {
            quizManager.correct();
        }
        else
        {
            quizManager.QuizSkip();
        }
        SetColor(Color.white);
        AddTime();
    }

}
