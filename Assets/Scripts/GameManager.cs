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
        // Invoke("Restart", restartDelay);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        theScoreManager.scoreIncreasing = true;
    }

    //public void ShowGameOverMenu()
    //{
    //    gameOverMenu = GameObject.FindWithTag("Game Over");
    //    gameOverMenu.SetActive(true);
    //}
}
