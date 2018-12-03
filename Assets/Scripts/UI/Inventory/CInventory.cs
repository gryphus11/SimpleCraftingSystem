using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CInventory : MonoBehaviour
{
    // 플레이어가 가진 아이템
    public List<CItem> playerItems = new List<CItem>();

    [SerializeField]
    private CUIInventory _uiInventory = null;
    private CItemDatabase _itemDatabase = null;

    private void Awake()
    {
        Debug.Log(Application.persistentDataPath + "/Brunhild/Bundles/");
        if (_itemDatabase == null)
        {
            _itemDatabase = CAssetBundleManager.GetItemDatabase();
        }
    }

    private void Start()
    {
        GiveItem(100);
        GiveItem(101);
        GiveItem(101);
        GiveItem(101);
        GiveItem(101);
        GiveItem(101);
        GiveItem(102);
        GiveItem(103);
        GiveItem(103);
        GiveItem(103);
        GiveItem(103);
        GiveItem(103);
        GiveItem(103);
        GiveItem(103);
        GiveItem(103);
        GiveItem(103);
        GiveItem(103);
        GiveItem(103);
        GiveItem(103);
        GiveItem(103);
        GiveItem(103);
    }

    public void GiveItem(int id)
    {
        if (!CheckItemDatabase())
        {
            return;
        }

        CItem itemToAdd = _itemDatabase.GetItem(id);
        playerItems.Add(itemToAdd);
        _uiInventory.AddItemToUI(itemToAdd);
    }

    public void GiveItem(string title)
    {
        if (!CheckItemDatabase())
        {
            return;
        }

        CItem itemToAdd = _itemDatabase.GetItem(title);
        playerItems.Add(itemToAdd);
        _uiInventory.AddItemToUI(itemToAdd);
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

    private bool CheckItemDatabase()
    {
        if (_itemDatabase == null)
        {
            return false;
        }

        return true;
    }
}
