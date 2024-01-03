using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonNextLevel : MonoBehaviour
{
    private UiManager uiManager;

    private void Awake()
    {
        uiManager = GameObject.Find("Canvas").GetComponent<UiManager>();

        if(uiManager.getCurrentScore() < 24)
        {
            gameObject.SetActive(false);
        }
    }
}
