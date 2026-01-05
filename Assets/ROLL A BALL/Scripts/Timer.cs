using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class TimedScoreLevelManager : MonoBehaviour
{
    public ScoreDatas scoreData;
    public int scoreToWin = 6;
    public float timeLimit = 60f;
    public TextMeshProUGUI timerText;
    public AudioSource warningSound;
    private bool soundPlayed = false;
    public string winScene = "Victory";
    public string loseScene = "GameOverScene";
    private float timer;
    private bool levelEnded = false;

    void Update()
    {
        if (levelEnded || scoreData == null)
            return;

        timer += Time.deltaTime;
        float timeRemaining = Mathf.Clamp(timeLimit - timer, 0f, timeLimit);

        UpdateTimerUI(timeRemaining);

        if (timeRemaining <= 10f && !soundPlayed)
        {
            soundPlayed = true;
            if (warningSound != null)
                warningSound.Play();
        }

        if (scoreData.ScoreValue >= scoreToWin)
        {
            levelEnded = true;
            SceneManager.LoadScene(winScene);
        }
        else if (timeRemaining <= 0f)
        {
            levelEnded = true;
            SceneManager.LoadScene(loseScene);
        }
    }

    void UpdateTimerUI(float timeRemaining)
    {
        int minutes = Mathf.FloorToInt(timeRemaining / 60f);
        int seconds = Mathf.FloorToInt(timeRemaining % 60f);

        timerText.text = $"{minutes:00}:{seconds:00}";
    }
}
