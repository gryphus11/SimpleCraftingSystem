using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CUIItem : MonoBehaviour, IPointerDownHandler
{
    public CItem item = null;
    public bool isCraftingSlot = false;

    private Image _icon = null;

    private static CUIItem _selectedItem = null;
    private static CCraftingSlots _craftingSlot = null;

    private void Awake()
    {
        _icon = GetComponent<Image>();
        UpdateItem(null);
    }

    private void Start()
    {
        if (_selectedItem == null)
        {
            _selectedItem = GameObject.Find("SelectedItem").GetComponent<CUIItem>();
            _selectedItem.UpdateItem(null);
        }

        if (_craftingSlot == null)
        {
            _craftingSlot = FindObjectOfType<CCraftingSlots>();
        }
    }

    public void UpdateItem(CItem item)
    {
        this.item = item;

        if (item != null)
        {
            _icon.color = Color.white;
            _icon.sprite = item.icon;
            if (_icon.sprite == null)
                _icon.color = Color.clear;
        }
        else
        {
            _icon.color = Color.clear;
        }

        if (isCraftingSlot)
        {
            _craftingSlot.UpdateRecipe();
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (item != null)
        {
            if (_selectedItem.item != null)
            {
                CItem cloneItem = new CItem(_selectedItem.item);
                _selectedItem.UpdateItem(item);
                UpdateItem(cloneItem);
            }
            else
            {
                _selectedItem.UpdateItem(item);
                UpdateItem(null);
            }
        }
        else if (_selectedItem.item != null)
        {
            UpdateItem(_selectedItem.item);
            _selectedItem.UpdateItem(null);
        }
    }
}
