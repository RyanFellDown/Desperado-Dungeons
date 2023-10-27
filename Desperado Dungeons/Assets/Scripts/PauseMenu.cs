using System.Diagnostics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    //need to close inventory UI

    public static bool isGamePaused = false; //you can reference THIS variable from other scripts to see if the game is paused!!!
    public GameObject pauseMenuUI;

    //On escape key press, the pause menu is brought up from this update function.
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isGamePaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }


    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        isGamePaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        isGamePaused = true;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Title Start");
    }
    public void QuitGame()
    {
        UnityEngine.Debug.Log("Quitting...");
        Application.Quit();
    }

}
