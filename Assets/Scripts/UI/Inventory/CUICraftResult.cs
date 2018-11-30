using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CUICraftResult : MonoBehaviour, IPointerDownHandler
{
    [SerializeField]
    private CSlotPanel _slotPanel = null;

    [SerializeField]
    private CInventory _inventory = null;

    /// <summary>
    /// 조합완료 칸을 누른 경우
    /// </summary>
    /// <param name="eventData"></param>
    public void OnPointerDown(PointerEventData eventData)
    {
        _slotPanel.EmptyAllSlots();
        _inventory.playerItems.Add(GetComponent<CUIItem>().item);
    }
}
