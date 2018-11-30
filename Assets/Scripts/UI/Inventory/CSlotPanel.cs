using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSlotPanel : MonoBehaviour {
    public List<CUIItem> uiItems = new List<CUIItem>();
    public int numberOfSlots = 24;

    [SerializeField]
    private GameObject _slotPrefab = null;

    private void Awake()
    {
        for (int i = 0; i < numberOfSlots; ++i)
        {
            GameObject slotInstance = Instantiate(_slotPrefab);
            slotInstance.transform.SetParent(transform);
            slotInstance.name = "Slot " + i;
            CUIItem uiItem = slotInstance.GetComponentInChildren<CUIItem>();
            uiItem.UpdateItem(null);
            uiItems.Add(uiItem);
        }
    }

    private void UpdateSlot(int slot, CItem item)
    {
        if (slot < 0 || slot >= numberOfSlots)
        {
            return;
        }

        uiItems[slot].UpdateItem(item);
    }

    public void AddNewItem(CItem item)
    {
        UpdateSlot(uiItems.FindIndex(slotItem => slotItem.item == null), item);
    }

    public void RemoveItem(CItem item)
    {
        UpdateSlot(uiItems.FindIndex(slotItem => slotItem.item == item), null);
    }

    public bool ContainsEmptySlot()
    {
        foreach (CUIItem uiItem in uiItems)
        {
            if (uiItem.item == null)
            {
                return true;
            }
        }

        return false;
    }
}
