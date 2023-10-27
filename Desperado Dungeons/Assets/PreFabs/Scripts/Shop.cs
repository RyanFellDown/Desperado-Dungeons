using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Shop : MonoBehaviour
{
    public bool playerOpenedShop = false; //you can reference THIS variable from other scripts to see if the game is paused!!!
    private int coins;
    public GameObject shopMenuUI;
    public Playable_Character_Script player;

    void Start()
    {
        //start by initializing with player object
        player = FindObjectOfType<Playable_Character_Script>();
    }

    public void OpenShop()
    {
        shopMenuUI.SetActive(true);
        Time.timeScale = 0f;
        playerOpenedShop = true;
    }

    public void CloseShop()
    {
        shopMenuUI.SetActive(false);
        Time.timeScale = 1f;
        playerOpenedShop = false;
    }

    //This lets the player buy health to full
    public void BuyHealth()
    {
        Debug.Log(FindObjectOfType<CoinCounter>().NumberOfCoins());
        coins = FindObjectOfType<CoinCounter>().NumberOfCoins();
        if (coins >= 10)
        {
            //If the player has less than full health, they heal and spend 10 coins
            if (player.currentHealth <= player.maxHealth)
            {
                player.currentHealth = player.maxHealth;
                FindObjectOfType<CoinCounter>().SubtractCoins(10);
            }
        }
    }

    //This lets the player buy extra health
    public void BuyShield()
    {
        coins = FindObjectOfType<CoinCounter>().NumberOfCoins();
        Debug.Log(coins);
        if (coins >= 15)
        {
            player.maxHealth += 20; //add 30 health to the max health a player can have
            player.currentHealth += 20; //add 20 more health to the player
            FindObjectOfType<CoinCounter>().SubtractCoins(15);
        }
    }

    //This lets the player have a stronger attack
    public void BuyAttackDamage()
    {
        coins = FindObjectOfType<CoinCounter>().NumberOfCoins();
        if (coins >= 25)
        {
            player.attackDamage += 15;
            FindObjectOfType<CoinCounter>().SubtractCoins(25);
        }
    }
}
