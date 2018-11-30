using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CUIInventory : MonoBehaviour
{
    [SerializeField]
    private CSlotPanel[] slotPanels = null;

    //public static CUIItem selectedItem = null;

    private void Start()
    {
        //selectedItem = GameObject.Find("SelectedItem").GetComponent<CUIItem>();
    }

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
