using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolBarUI : MonoBehaviour
{
    [SerializeField] private List<SlotUI> toolbarSlots = new List<SlotUI>();
    private SlotUI selectedSlot;

    private void Start()
    {
        selectASlot(0);
        for(int i = 0; i<5; i++)
        {
            selectASlot(i);
            selectedSlot.SetHighlight(false);
        }
        selectASlot(0);
        selectedSlot.SetHighlight(true);
    }

    private void Update()
    {
        CheckWhichSlotSelected();
    }

    public void selectASlot(int slotIndex)
    {
        if (toolbarSlots.Count == 5) {
            if(selectedSlot != null)
            {
                selectedSlot.SetHighlight(false);
            }
            selectedSlot = toolbarSlots[slotIndex];
            selectedSlot.SetHighlight(true);
        }
    }

    private void CheckWhichSlotSelected()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            selectASlot(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            selectASlot(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            selectASlot(2);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            selectASlot(3);
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            selectASlot(4);
        }
    }

}
