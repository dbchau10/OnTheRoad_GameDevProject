using UnityEngine;
using UnityEngine.UI;

public class FinishStarByLevel : MonoBehaviour
{
    public Sprite img1Star;
    public Sprite img2Star;
    public Sprite img3Star;
    private Image spriteRenderer;
    private UiManager uiManager;

    private void Awake()
    {
        uiManager = GameObject.Find("Canvas").GetComponent<UiManager>();
        spriteRenderer = gameObject.GetComponent<Image>();
    }

    private void OnEnable()
    {
        if (spriteRenderer)
        {
            ChangeImage(uiManager.getCurrentScore());
        }
    }

    public void ChangeImage(double score)
    {
        if (score >= 27)
        {
            spriteRenderer.sprite = img3Star;
        }
        else if (score >= 20)
        {
            spriteRenderer.sprite = img2Star;
        }
        else
        {
            spriteRenderer.sprite = img1Star;
        }
    }
}
