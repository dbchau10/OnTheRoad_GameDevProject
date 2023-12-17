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

     LightState currentLightState;

      public LightState trafficLightState { get {return currentLightState; } set {currentLightState = value; }}


    void Start()
    {
        spriteRenderer = GetComponent <SpriteRenderer>();
        SetLightState(LightState.Green);
        StartCoroutine(TrafficLightCycle());
    }

    IEnumerator TrafficLightCycle()
    {
        while (true)
        {
            yield return new WaitForSeconds(greenLightTime);
            SetLightState(LightState.Red);

            yield return new WaitForSeconds(redLightTime);
            SetLightState(LightState.Yellow);

            yield return new WaitForSeconds(yellowLightTime);
            SetLightState(LightState.Green);
        }
    }

    public void SetLightState(LightState newState)
    {
        currentLightState = newState;

        switch (currentLightState)
        {
            case LightState.Red:
                spriteRenderer.sprite = redLight;
                break;
            case LightState.Yellow:
                spriteRenderer.sprite = yellowLight;
                break;
            case LightState.Green:
                spriteRenderer.sprite = greenLight;
                break;
            default:
                break;
        }
    }
}

