using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreen : MonoBehaviour
{

    public bool playerIsDead = false; //you can reference THIS variable from other scripts to see if the game is paused!!!
    public GameObject deathMenuUI;
    public Playable_Character_Script player;
    int currentHealth;

    void Start()
    {
        //start by initializing with player object and setting currentHealth

        player = FindObjectOfType<Playable_Character_Script>();
        currentHealth = player.currentHealth;
        Debug.Log(currentHealth);
    }

    void Update()
    {
        //then, set player object again and set health continuously to save data between scenes,
        //also stops immediate death screen and death screen on scene change

        player = FindObjectOfType<Playable_Character_Script>();
        currentHealth = player.currentHealth;
        /*
        if ((currentHealth <= 0) && (playerIsDead == true))
        {
            if(Time.deltaTime > 1 && currentHealth <= 0)
            {
                Death();
            }
            else
            {
                playerIsDead = false;
            }
        }
        */
        if(currentHealth<=0)
        {
            Death();
        }
        else if (currentHealth > 0)
        {
            NoDeath();
        }
    }


    public void Death()
    {
        deathMenuUI.SetActive(true);
        Time.timeScale = 0f;
        playerIsDead = true;
    }

    public void NoDeath()
    {
        deathMenuUI.SetActive(false);
        playerIsDead = false;
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
