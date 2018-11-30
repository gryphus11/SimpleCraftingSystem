using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CInventory : MonoBehaviour
{
    // 플레이어가 가진 아이템
    public List<CItem> playerItems = new List<CItem>();

    private CItemDatabase _itemDatabase = null;

    private void Awake()
    {
        if (_itemDatabase == null)
        {
            _itemDatabase = Resources.Load<CItemDatabase>(CUtillity.databaseResourcesPath + "ItemDatabase");
        }
    }

    public void GiveItem(int id)
    {
        if (!CheckItemDatabase())
        {
            return;
        }

        CItem itemToAdd = _itemDatabase.GetItem(id);
        playerItems.Add(itemToAdd);
    }

    public void GiveItem(string title)
    {
        if (!CheckItemDatabase())
        {
            return;
        }

        CItem itemToAdd = _itemDatabase.GetItem(title);
        playerItems.Add(itemToAdd);
    }

    public CItem CheckForItem(int id)
    {
        return playerItems.Find(item => item.id == id);
    }

    public void RemoveItem(int id)
    {
        CItem itemToRemove = CheckForItem(id);

        if (itemToRemove != null)
        {
            playerItems.Remove(itemToRemove);
        }
    }

    public bool CheckItemDatabase()
    {
        if (_itemDatabase == null)
        {
            _itemDatabase = Resources.Load<CItemDatabase>(CUtillity.databaseResourcesPath + "ItemDatabase");
        }

        if (_itemDatabase == null)
        {
            return false;
        }

        return true;
    }
}
