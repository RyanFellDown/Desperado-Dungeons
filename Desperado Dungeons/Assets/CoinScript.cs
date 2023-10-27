using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    public static int totalCoins = 0;

    //This basically makes something happen whenever Player collision
    //occurs with this object.
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            FindObjectOfType<AudioManager>().PlaySound("CoinPickup");
            totalCoins++;
            Destroy(gameObject);
        }
    }
}
