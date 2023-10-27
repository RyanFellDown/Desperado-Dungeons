using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryScript : MonoBehaviour
{

    #region Singleton
    public static InventoryScript instance;    //variable shared by all instances

    void Awake()
    {
        if(instance != null)
        {
            Debug.LogWarning("More than one inventory has been created!");
            return;
        }
        instance = this;
        //when starting game, we set that variable equal to this specific componenet
        //ALSO sets it so there's only 1 inventory at a time
    }

    #endregion

    public delegate void OnItemChanged();
    public OnItemChanged OnItemChangeCallback;

    public List<Item> items = new List<Item>();
    public int totalInventorySpace = 25;


    //Basically, it checks if you got enough space in the inventory to pick up an item.
    //If yes, it adds the item AND destroys it in ItemPickup.
    //Otherwise, it tells you "NO" and leaves the item as is.
    public bool Add(Item item)
    {
        if (!item.defaultItem)
        {
            if (items.Count >= totalInventorySpace)
            {
                Debug.Log("Nah you got too much stuff");
                return false;
            }
            items.Add(item);

            if (OnItemChangeCallback != null)
            {
                OnItemChangeCallback.Invoke();
            }
        }
      
        return true;
    }

    public void Remove(Item item)
    {
        items.Remove(item);
        if (OnItemChangeCallback != null)
        {
            OnItemChangeCallback.Invoke();
        }
    }

}
