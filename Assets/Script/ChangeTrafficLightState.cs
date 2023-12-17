using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeTrafficLightState : MonoBehaviour
{
    public Sprite redLight;
    public Sprite yellowLight;
    public Sprite greenLight;

    public float redLightTime = 20f;
    public float yellowLightTime = 3f;
    public float greenLightTime = 15f;

    private SpriteRenderer spriteRenderer;

    public enum LightState
    {
        Red,
        Yellow,
        Green
    }

     public string  currentLightState;

   


    void Start()
    {
        spriteRenderer = GetComponent <SpriteRenderer>();
        SetLightState("Green");
        StartCoroutine(TrafficLightCycle());
    }

    IEnumerator TrafficLightCycle()
    {
        while (true)
        {
            yield return new WaitForSeconds(greenLightTime);
            SetLightState("Red");

            yield return new WaitForSeconds(redLightTime);
            SetLightState("Yellow");

            yield return new WaitForSeconds(yellowLightTime);
            SetLightState("Green");
        }
    }

    public void SetLightState(string newState)
    {
        currentLightState = newState;

        switch (currentLightState)
        {
            case "Red":
                spriteRenderer.sprite = redLight;
                break;
            case "Yellow":
                spriteRenderer.sprite = yellowLight;
                break;
            case "Green":
                spriteRenderer.sprite = greenLight;
                break;
            default:
                break;
        }
    }
}

