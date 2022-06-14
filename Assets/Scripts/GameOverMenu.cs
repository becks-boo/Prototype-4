using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    private ScoreManager theScoreManager;

    public void ShowGameOverMenu()
    {
        theScoreManager = FindObjectOfType<ScoreManager>();
        theScoreManager.scoreIncreasing = false;
        gameObject.SetActive(true);
    }

    public void RestartButton()
    {
        // Physics reset before loading new scene, otherwise jump inconsistent
        Physics.gravity = new Vector3(0, -9.8f, 0);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitButton()
    {
        Application.Quit();
    }
}
