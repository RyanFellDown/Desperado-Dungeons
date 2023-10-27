using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChestFinishGame : MonoBehaviour
{
    public bool playerOpenedChest = false; //you can reference THIS variable from other scripts to see if the game is paused!!!
    public GameObject winMenuUI;
    public Playable_Character_Script player;

    void Start()
    {
        //start by initializing with player object
        player = FindObjectOfType<Playable_Character_Script>();
    }

    public void Win()
    {
        winMenuUI.SetActive(true);
        Time.timeScale = 0f;
        playerOpenedChest = true;
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
