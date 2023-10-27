using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[System.Serializable]
public class Inventory
{
    [System.Serializable]
    public class Slot
    {
        public string itemName;
        public int countSlot;
        public int maxItems;

        public Sprite icon;
        public Slot()
        {
            itemName = "";
            countSlot = 0;
            maxItems = 1;
        }
        public bool isEmpty
        {
            get{ 
                if(itemName == "" && countSlot == 0)
                {
                    return true;
                }
                return false;
            }
        }
        public bool CanAddItem(string itemName)
        {
            if (this.itemName == itemName && countSlot < maxItems)
            {
                Debug.Log("it CAN add the item");
                return true;
            }
            Debug.Log("it CAN'T add the item");
            return false;
        }

        public void AddItem(Item2D item)
        {
            itemName = item.itemData.itemName;
            icon = item.itemData.icon;
            countSlot++;
            Debug.Log("So, the itemType HAS been changed to ");
            Debug.Log(itemName);
        }

        public void AddItem(string itemName, Sprite icon, int maxAllowed)
        {
            this.itemName = itemName;
            this.icon = icon;
            countSlot++;
            maxItems = maxAllowed;
            Debug.Log("So, the itemType HAS been changed to ");
            Debug.Log(itemName);
        }

        public void RemoveItem()
        {
            if (countSlot > 0)
            {
                countSlot--;
                if (countSlot == 0)
                {
                    icon = null;
                    itemName = "";
                }
            }
        }
    }


    public List<Slot> slots = new List<Slot>();

    public Inventory(int numberOfSlots)
    {
        for(int y = 0; y< numberOfSlots; y++)
        {
            Slot slot = new Slot();
            slots.Add(slot);
        }
    }

    public void Add(Item2D item)
    {
        Debug.Log("ok still working");
        foreach (Slot slot in slots)
        {
            if(slot.itemName == item.itemData.itemName && slot.CanAddItem(item.itemData.itemName))
            {
                slot.AddItem(item);
                Debug.Log("did the first foreach");
                return;
            }
        }

        foreach(Slot slot in slots)
        {
            if (slot.itemName == "")
            {
                Debug.Log(slot.itemName);
                slot.AddItem(item);
                Debug.Log("did the SECOND foreach");
                return;
            }
        }

    }

    public void Remove(int indexItem)
    {
        slots[indexItem].RemoveItem();
    }

    public void Remove(int indexItem, int numberToRemove)
    {
        if (slots[indexItem].countSlot >= numberToRemove)
        {
            for(int x = 0; x<numberToRemove; x++)
            {
                Remove(indexItem);
            }
        }
    }

    //Basically just makes it so if the slot we want to place an item on is empty AND can add that item
    //we add that item to the ending slot, and destroy the item fromm the beginning slot
    public void MoveSlot(int firstIndex, int endingIndex, Inventory toInventory, int amountToMove = 1)
    {
        Slot firstSlot = slots[firstIndex];
        Slot endingSlot = toInventory.slots[endingIndex];

        if(endingSlot.isEmpty || endingSlot.CanAddItem(firstSlot.itemName))
        {
            for(int x = 0; x < amountToMove; x++)
            {
                endingSlot.AddItem(firstSlot.itemName, firstSlot.icon, firstSlot.maxItems);
                firstSlot.RemoveItem();
            }
        }
    }
}
