using UnityEngine;


[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]

//This scipt is basically a blueprint for the rest of our items in the game.

public class Item : ScriptableObject
{
    new public string name = "New Item";
    public Sprite icon = null;
    public bool defaultItem = false;
}
