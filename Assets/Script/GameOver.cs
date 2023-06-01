using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public GameObject gameOver;

    private void OnEnable()
    {
        PlayerHealth.OnPlayerDeath += EnableGameOver;
    }

    private void OnDisable()
    {
        PlayerHealth.OnPlayerDeath -= EnableGameOver;
    }


    public void EnableGameOver()
    {
        gameOver.SetActive(true);
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
