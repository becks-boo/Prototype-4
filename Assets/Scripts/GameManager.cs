using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float restartDelay = 3.0f;
    public GameOverMenu gameOverMenu;

    private ScoreManager theScoreManager;

    private void Start()
    {
        theScoreManager = FindObjectOfType<ScoreManager>();
    }

    public void EndGame()
    {
        theScoreManager.scoreIncreasing = false;

        Debug.Log("GAME OVER!");
        gameOverMenu.ShowGameOverMenu();
    }
}
