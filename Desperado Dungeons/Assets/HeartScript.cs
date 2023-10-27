using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartScript : MonoBehaviour
{
    public static int addHealth = 20;

    //This basically makes something happen whenever Player collision
    //occurs with this object.
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            FindObjectOfType<AudioManager>().PlaySound("HeartPickup");
            Destroy(gameObject);
            collision.GetComponent<Playable_Character_Script>().RegainHealth(addHealth);
        }
    }
}
