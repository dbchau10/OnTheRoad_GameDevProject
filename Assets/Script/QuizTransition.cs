using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizTransition : MonoBehaviour
{
    bool pause = false;
    public void OnEnable()
    {
        pause = true;
        LeanTween.reset();
        LeanTween.moveLocalX(gameObject, 0f, 0.5f).setEase(LeanTweenType.easeInOutCirc).setDelay(0.5f).setOnComplete(OnPause);
    }

    void OnPause()
    {
        if (pause)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1;
        }
    }

    public void CloseQuiz()
    {
        pause = false;
        LeanTween.moveLocalX(gameObject, -1918f, 1f).setEase(LeanTweenType.easeInOutCirc).setDelay(0.5f).setOnComplete(OnPause);
    }
}
