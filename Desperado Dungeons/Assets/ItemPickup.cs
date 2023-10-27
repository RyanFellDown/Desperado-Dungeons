using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public Item item;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("Picking up " + item.name);
            bool enoughSpace = InventoryScript.instance.Add(item);
            if (enoughSpace)
            {
                Destroy(gameObject);
            }
        }
    }

}
