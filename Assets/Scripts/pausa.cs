using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pausa : MonoBehaviour
{
    public GameObject pauseMenuUI;  // arraste o painel aqui no Inspector
    private bool isPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
                Resume();
            else
                Pause();
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;  // Volta ao tempo normal
        isPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;  // Pausa o tempo
        isPaused = true;
    }

    public void QuitGame()
    {
        Debug.Log("Saindo do jogo...");
        Application.Quit();  // Só funciona no build
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;  // Garante que o tempo volte ao normal
        UnityEngine.SceneManagement.SceneManager.LoadScene(
            UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }
}
