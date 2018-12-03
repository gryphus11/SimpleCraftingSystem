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

    /// <summary>
    /// 슬롯 판넬이 관리하는 모든 슬롯들 중에서 해당 인덱스에 아이템을 업데이트한다.
    /// 아이템이 존재하던 null 이던 업데이트함
    /// </summary>
    /// <param name="slot"></param>
    /// <param name="item"></param>
    private void UpdateSlot(int slot, CItem item)
    {
        if (slot < 0 || slot >= numberOfSlots)
        {
            return;
        }
        
        uiItems[slot].UpdateItem(item);
    }

    /// <summary>
    /// 빈 슬롯에 아이템 추가
    /// </summary>
    /// <param name="item"></param>
    public void AddNewItem(CItem item)
    {
        UpdateSlot(uiItems.FindIndex(slotItem => slotItem.item == null), item);
    }

    /// <summary>
    /// 아이템 제거
    /// </summary>
    /// <param name="item"></param>
    public void RemoveItem(CItem item)
    {
        UpdateSlot(uiItems.FindIndex(slotItem => slotItem.item == item), null);
    }

    /// <summary>
    /// 빈 슬롯을 찾음
    /// </summary>
    /// <returns></returns>
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

    /// <summary>
    /// 모든 슬롯을 비운다. (모든 슬롯을 null 로 업데이트)
    /// </summary>
    public void EmptyAllSlots()
    {
        uiItems.ForEach(item => item.UpdateItem(null));
    }
}
