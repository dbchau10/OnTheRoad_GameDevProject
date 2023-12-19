using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    [SerializeField]
    private Text _scoreText;
    [SerializeField]
    private Text _gameOverText;
    [SerializeField]
    private Text _restartText;

    private float startTime;
    private float restSeconds;
    private int roundedRestSeconds;
    private float displaySeconds;
    private float displayMinutes;
    public int CountDownSeconds = 120;
    [SerializeField]
    private Text _timer;
    private float Timeleft;
    string timetext;

    public static Timer instance;

    public GameManagerUI gameUIControl;

    public void changeScore(double score)
    {
        _scoreText.text = "Score: " + score;
    }

    // Start is called before the first frame update
    void Start()
    {
        _scoreText.text = "Score: 0";
        startTime = Time.deltaTime;
    }

    public void AdjustTimeLeft(int amount)
    {
        if(amount < 0)
        {
            StartCoroutine(changeTextColor(_scoreText, 2.0f));
        }
        restSeconds = Mathf.Clamp(restSeconds + amount, 0, CountDownSeconds);
    }

    IEnumerator changeTextColor(Text textObject, float time)
    {
        while(time > 0)
        {
            time -= Time.deltaTime;
            textObject.color = Color.Lerp(Color.white, Color.red, time);
            yield return null;
        }

        textObject.color = Color.white;
    }

    // Update is called once per frame
    void Update()
    {
        Timeleft = Time.time - startTime;
        restSeconds = CountDownSeconds - (Timeleft);
        
        roundedRestSeconds = Mathf.CeilToInt(restSeconds);
        displaySeconds = roundedRestSeconds % 60;
        displayMinutes = (roundedRestSeconds / 60) % 60;

        timetext = (displayMinutes.ToString() + ":");
        bool gameDone = FindObjectOfType<GameManagerUI>().gameDone;
        if (gameDone){
             timetext = "00:00";
        }else {
        if (displaySeconds > 9)
        {
            timetext = timetext + displaySeconds.ToString();
        }
        else if (displaySeconds >=0)
        {
            timetext = timetext + "0" + displaySeconds.ToString();
        }
        else
        {
            timetext = timetext + "00";
        }
        }
        _timer.text = timetext;

        if (restSeconds <= 0) GameOverSequence();
    }

    void GameOverSequence()
    {
        // _gameOverText.gameObject.SetActive(true);
        // _restartText.gameObject.SetActive(true);
        GameObject.Find("GameManager").GetComponent<GameManager>().GameOver();
        gameUIControl.GetComponent<GameManagerUI>().GameOver();
           
        // StartCoroutine(flickering());
    }

    IEnumerator flickering()
    {
        while (true)
        {
            _gameOverText.text = "GAME OVER";
            yield return new WaitForSeconds(0.5f);
            _gameOverText.text = "";
            yield return new WaitForSeconds(0.5f);
        }
    }
}
