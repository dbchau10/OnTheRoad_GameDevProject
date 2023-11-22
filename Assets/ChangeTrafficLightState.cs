using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeTrafficLightState : MonoBehaviour
{
    public Sprite redLight;
    public Sprite yellowLight;
    public Sprite greenLight;

    private SpriteRenderer spriteRenderer;

    public enum LightState
    {
        Red,
        Yellow,
        Green
    }

    public LightState currentLightState;

    void Start()
    {
        spriteRenderer = GetComponent <SpriteRenderer>();
        StartCoroutine(TrafficLightCycle());
    }

    IEnumerator TrafficLightCycle()
    {
        while (true)
        {
            yield return new WaitForSeconds(4f);
            SetLightState(LightState.Red);

            yield return new WaitForSeconds(2f);
            SetLightState(LightState.Yellow);

            yield return new WaitForSeconds(2f);
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

