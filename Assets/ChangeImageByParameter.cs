using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangeImageByParameter : MonoBehaviour
{
    public int stateStar;
    public Sprite img1Star;
    public Sprite img2Star;
    public Sprite img3Star;
    private Image spriteRenderer;

    void Awake()
    {
        spriteRenderer = gameObject.GetComponent<Image>();
        if (spriteRenderer)
        {
            ChangeImage(stateStar);

        }
    }

    private void Update()
    {
      
    }

    public void ChangeImage(int imageNumber)
    {
        switch (imageNumber)
        {
            case 1:
                spriteRenderer.sprite = img1Star;
                break;
            case 2:
                spriteRenderer.sprite = img2Star;
                break;
            case 3:
                spriteRenderer.sprite = img3Star;
                break;
            default:
                Debug.LogError("Invalid image number!");
                break;
        }
    }
}
