using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleTween : MonoBehaviour
{
    public GameObject QuizScene;
    public GameObject QuizMarathon;

    public void OnEnable()
    {
        LeanTween.reset();
        LeanTween.scale(gameObject, new Vector3(1, 1, 1), 0.5f).setDelay(1f).setOnComplete(
            delegate () { 
                LeanTween.scale(gameObject, new Vector3(0, 0, 0), 0.5f).setOnComplete(
                    delegate() { 
                        DestroyMe(); 
                    }); });
    }


    void DestroyMe()
    {
        QuizScene.SetActive(true);
        QuizMarathon.GetComponent<QuizManager>().QuizTest = true;

        gameObject.SetActive(false);
    }
}
