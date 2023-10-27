using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public void ChangeScene()
    {
        if(FindAnyObjectByType<Playable_Character_Script>() != null)
        {
            FindAnyObjectByType<Playable_Character_Script>().currentHealth = FindAnyObjectByType<Playable_Character_Script>().maxHealth;
        }
        SceneManager.LoadScene(0);
        FindAnyObjectByType<Playable_Character_Script>().transform.position = new Vector3(-8.500977f, -0.7723389f, 0f);
        FindAnyObjectByType<CameraController>().transform.position = new Vector3(-8.500977f, -0.7723389f, -10f);
        FindAnyObjectByType<Playable_Character_Script>().animator.SetBool("IsDead", false);
        Time.timeScale = 1f;
    }
}
