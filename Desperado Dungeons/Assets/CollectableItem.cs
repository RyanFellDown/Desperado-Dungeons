using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Item2D))]
public class CollectableItem : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Playable_Character_Script player = collision.GetComponent<Playable_Character_Script>();
        if (player)
        {
            Item2D item = GetComponent<Item2D>();
            if(item != null)
            {
                player.inventory.Add("Backpack", item);
                Destroy(gameObject);
            }
        }
    }
}