using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldScript : MonoBehaviour
{
    public bool destroyed;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Playable_Character_Script player = collision.GetComponent<Playable_Character_Script>();
        if (player)
        {
            destroyed = true;
            Debug.Log("Destroyed set to " + destroyed);
            Destroy(gameObject);
        }
    }
}
