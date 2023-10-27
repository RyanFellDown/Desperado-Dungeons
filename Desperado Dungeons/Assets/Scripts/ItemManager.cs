using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class ItemManager : MonoBehaviour
{
    public Item2D[] items;

    private Dictionary<string, Item2D> nameToItemDictionary = new Dictionary<string, Item2D>();

    private void Awake()
    {
        foreach(Item2D item in items)
        {
            AddItem(item);
        }
    }

    private void AddItem(Item2D item)
    {
        if (!nameToItemDictionary.ContainsKey(item.itemData.itemName))
        {
            nameToItemDictionary.Add(item.itemData.itemName, item);
        }
    }

    public Item2D returnItemByName(string key)
    {
        if (nameToItemDictionary.ContainsKey(key))
        {
            return nameToItemDictionary[key];
        }
        return null;
    }
}
