using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{
    /*
    public Dictionary<string, Inventory_UI> inventoryUIName = new Dictionary<string, Inventory_UI>();
    public GameObject inventoryPanel;
    public List<Inventory_UI> inventoryUIs;

    public static SlotUI draggedSlot;
    public static Image draggedIcon;
    public static bool dragSingle;
    
    //on game startup, initialize the UI
    private void Awake()
    {
        Initialize();
    }

    /*
    private void Start()
    {
        ToggleInventory();
    }
    */

    /*
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            ToggleInventory();
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            dragSingle = true;
        }
        else
        {
            dragSingle = false;
        }
    }

    //toggles the inventory on or off.
    public void ToggleInventory()
    {
        if (inventoryPanel != null)
        {
            if (!inventoryPanel.activeSelf)
            {
                inventoryPanel.SetActive(true); //sets inventoryPanel to open
                RefreshInventoryUI("Backpack");
            }
            else
            {
                inventoryPanel.SetActive(false); //sets inventoryPanel to closed
            }
        }
    }

    public void RefreshInventoryUI(string inventoryName)
    {
        if (inventoryUIName.ContainsKey(inventoryName))
        {
            inventoryUIName[inventoryName].Refresh();
        }
    }
    
    public void RefreshAll()
    {
        foreach(KeyValuePair<string, Inventory_UI> keyValuePair in inventoryUIName)
        {
            keyValuePair.Value.Refresh();
        }
    }


    //this gets the inventory UI for us to cross from inventory to toolbar
    public Inventory_UI GetInventory_UI(string InventoryName)
    {
        if (inventoryUIName.ContainsKey(InventoryName))
        {
            return inventoryUIName[InventoryName];
        }
        Debug.LogWarning("NO INVENTORTY ASDFDFSDFb");
        return null;
    }

    void Initialize()
    {
        foreach(Inventory_UI ui in inventoryUIs)
        {
            inventoryUIName.Add(ui.inventoryName, ui);
        }
    }
    */
}
