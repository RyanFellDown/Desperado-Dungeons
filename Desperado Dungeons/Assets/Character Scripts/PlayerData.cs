using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int currentHealth;

    //This constructor saves the Player's health between scenes.
    public PlayerData(Playable_Character_Script player)
    {
        currentHealth = player.currentHealth;
    }

}
