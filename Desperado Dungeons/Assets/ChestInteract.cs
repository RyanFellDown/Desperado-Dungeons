using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChestInteract : MonoBehaviour
{
    public ChestFinishGame chest;
    public Dragon_Boss dragon;
    public Animator chestAnimation;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (dragon.dragonIsDead == true) {
            if (collision.gameObject.CompareTag("Player") == true)
            {
                chestAnimation.SetBool("IsOpen", true);
                chest.Win();
            }
        }
    }
}
