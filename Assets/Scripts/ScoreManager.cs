using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highscoreText;

    public float scoreCount;
    public float highscoreCount;
    public float pointsPerEnemy;

    public bool scoreIncreasing;

    // public bool scoreIncreasing;

    void Start()
    {
        if (PlayerPrefs.HasKey("Highscore"))
        {
            highscoreCount = PlayerPrefs.GetFloat("Highscore");
        }
    }

    void Update()
    {
        if (scoreIncreasing)
        {
            scoreCount += pointsPerEnemy;
        }

        if (scoreCount > highscoreCount)
        {
            highscoreCount = scoreCount;
            PlayerPrefs.SetFloat("Highscore", highscoreCount);
        }

        scoreText.text = "Score: " + Mathf.Round(scoreCount);
        highscoreText.text = "Highscore: " + Mathf.Round(highscoreCount);
    }

    public void AddScore(int pointsToAdd)
    {
        scoreCount += pointsToAdd;
    }
}
