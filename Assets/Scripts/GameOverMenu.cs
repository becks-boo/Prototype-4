using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public void ShowGameOverMenu()
    {
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
