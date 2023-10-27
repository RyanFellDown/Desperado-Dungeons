using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterRooms : MonoBehaviour
{
    //private bool enterAllowed;
    public string sceneToLoad;
    private Playable_Character_Script player;
    //public LevelLoader levelLoadTransition;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            SceneManager.LoadScene(sceneToLoad);
            //levelLoadTransition.LoadNextLevel();
            player.healthBar.SetHealth(player.currentHealth);
        }
        /*
        else if (collision.GetComponent<Outside_First_House_Script>())
        {
            sceneToLoad = "Starting Level";  
            enterAllowed = true;
        }
        */
    }

    // Update is called once per frame
    /*
    void Update()
    {
        if(enterAllowed && Input.GetKey(KeyCode.X))
        {
            SceneManager.LoadScene(sceneToLoad);
            GetComponent<PlayerSpawnLocation>();
        }
    }
    */
}
