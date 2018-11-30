using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CUIInventory : MonoBehaviour
{
    [SerializeField]
    private CSlotPanel[] slotPanels = null;

    public void AddItemToUI(CItem item)
    {
        foreach (CSlotPanel slot in slotPanels)
        {
            if (slot.ContainsEmptySlot())
            {
                slot.AddNewItem(item);
                break;
            }
        }
    }
}
