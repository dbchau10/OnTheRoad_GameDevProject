using UnityEngine;
using UnityEngine.UI;

public class FinishQuiz : MonoBehaviour
{
    public Text scoreText;

    private void OnDisable()
    {
        if (scoreText != null)
        {
            LeanTween.scale(scoreText.gameObject, new Vector3(1.5f, 1.5f, 1.5f), 1f)
                .setEase(LeanTweenType.easeInOutSine)
                .setOnComplete(() => ChangeTextColor());
        }
    }

    private void ChangeTextColor()
    {
        if (scoreText != null)
        {
            Color originalColor = scoreText.color;
            LeanTween.value(scoreText.gameObject, originalColor, Color.yellow, 1f)
                .setOnUpdate((Color val) => scoreText.color = val)
                .setOnComplete(() => ScaleBack());
        }
    }

    private void ScaleBack()
    {
        if (scoreText != null)
        {
            LeanTween.scale(scoreText.gameObject, Vector3.one, 1f)
                .setEase(LeanTweenType.easeInOutSine)
                .setOnComplete(() => ChangeTextBackToWhite());
        }
    }

    private void ChangeTextBackToWhite()
    {
        if (scoreText != null)
        {
            Color originalColor = scoreText.color;
            LeanTween.value(scoreText.gameObject, originalColor, Color.white, 1f)
                .setOnUpdate((Color val) => scoreText.color = val);
        }
    }
}
