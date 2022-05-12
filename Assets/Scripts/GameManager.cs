using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float restartDelay = 3.0f;

    public GameOverMenu gameOverMenu;

    private void Start()
    {
        
    }

    public void EndGame()
    {
        Debug.Log("GAME OVER!");
        gameOverMenu.ShowGameOverMenu();
        // Invoke("Restart", restartDelay);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    //public void ShowGameOverMenu()
    //{
    //    gameOverMenu = GameObject.FindWithTag("Game Over");
    //    gameOverMenu.SetActive(true);
    //}
}
