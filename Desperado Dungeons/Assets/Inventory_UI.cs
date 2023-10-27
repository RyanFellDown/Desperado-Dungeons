using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory_UI : MonoBehaviour
{
    /*
    public string inventoryName;
    public List<SlotUI> slots = new List<SlotUI>();


    [SerializeField] private Canvas canvas;

    private bool dragSingle;
    private Inventory inventory;



    private void Awake()
    {
        canvas = FindObjectOfType<Canvas>();
    }

    private void Start()
    {
        inventory = GameManager.instance.player.inventory.GetInventoryByName(inventoryName);
        SetupSlots();
        Refresh();
    }

    /*
    public void ToggleInventoryOff()
    {
        inventoryPanel.SetActive(false); //sets inventoryPanel to closed
    }
    */

    /*
    public void Refresh()
    {
        if(slots.Count == inventory.slots.Count)
        {
            for(int x = 0; x<slots.Count; x++)
            {
                if (inventory.slots[x].itemName != "")
                {
                    slots[x].SetItem(inventory.slots[x]);
                }
                else
                {
                    slots[x].SetEmpty();
                }
            }
        }
    }

    public void Remove()
    {
        Item2D itemDrop = GameManager.instance.itemManager.returnItemByName(inventory.slots[UIManager.draggedSlot.slotNumber].itemName);
        
        if(itemDrop != null)
        {
            if (UIManager.dragSingle)
            {
                GameManager.instance.player.DropItem(itemDrop);
                inventory.Remove(UIManager.draggedSlot.slotNumber);
            }
            else
            {
                GameManager.instance.player.DropItem(itemDrop, inventory.slots[UIManager.draggedSlot.slotNumber].countSlot);
                inventory.Remove(UIManager.draggedSlot.slotNumber, inventory.slots[UIManager.draggedSlot.slotNumber].countSlot);
            }
            Refresh();
        }

        UIManager.draggedSlot = null;
    }

    //These functions allows for dragging an item in the inventory UI screen.
    //This one first starts the traggin by allow the user to click and pickup the item first
    public void startDraggingSlot(SlotUI slot)
    {
        UIManager.draggedSlot = slot;
        UIManager.draggedIcon = Instantiate(slot.itemIcon);
        UIManager.draggedIcon.raycastTarget = false;
        UIManager.draggedIcon.rectTransform.sizeDelta = new Vector2(50f, 50f);
        UIManager.draggedIcon.transform.SetParent(canvas.transform);

        MoveToMouse(UIManager.draggedIcon.gameObject);
        Debug.Log("starting " + slot.name);
    }

    //This function then proceeds to let them drag the icon
    public void SlotDrag()
    {
        MoveToMouse(UIManager.draggedIcon.gameObject);
        Debug.Log("dragging " + UIManager.draggedSlot.name);
    }

    //This one destroys the dragged icon once dropped
    public void endDraggingSlot()
    {
        Destroy(UIManager.draggedIcon.gameObject);
        UIManager.draggedIcon = null;

        Debug.Log("Done dragging " + UIManager.draggedSlot.name);
    }

    //And this one moves the item from one slot to another once dropped
    public void SlotDrop(SlotUI slot)
    {
        if (UIManager.dragSingle)
        {
            UIManager.draggedSlot.inventory.MoveSlot(UIManager.draggedSlot.slotNumber, slot.slotNumber, slot.inventory);
        }
        else
        {
            UIManager.draggedSlot.inventory.MoveSlot(UIManager.draggedSlot.slotNumber, slot.slotNumber, slot.inventory,
                UIManager.draggedSlot.inventory.slots[UIManager.draggedSlot.slotNumber].countSlot);
        }
        GameManager.instance.uiManager.RefreshAll();
    }

    private void MoveToMouse(GameObject moving)
    {
        if(canvas != null)
        {
            Vector2 position;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, Input.mousePosition, null, out position);
            moving.transform.position = canvas.transform.TransformPoint(position);
        }
    }

    void SetupSlots()
    {
        int counter = 0;
        foreach(SlotUI slot in slots)
        {
            slot.slotNumber = counter;
            counter++;
            slot.inventory = inventory;
        }
    }
    */
}