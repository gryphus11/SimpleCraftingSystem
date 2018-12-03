using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 아이템의 데이터를 가지는 클래스
/// </summary>
[System.Serializable]
public class CItem
{
    public int id = 0;
    public string title = string.Empty;
    public string description = string.Empty;
    public string iconPath = string.Empty;
    [SerializeField]
    public List<CItemStatus> status = new List<CItemStatus>();

    public CItem(int id, string title, string description, string iconPath, List<CItemStatus> status)
    {
        this.id = id;
        this.title = title;
        this.description = description;
        this.iconPath = iconPath;
        this.status = status;
    }

    public CItem(CItem item)
    {
        id = item.id;
        title = item.title;
        description = item.description;
        iconPath = item.iconPath;
        status = item.status;
    }

    public CItem()
    {
        id = 0;
        title = string.Empty;
        description = string.Empty;
        iconPath = string.Empty;
        status = new List<CItemStatus>();
    }
}

[System.Serializable]
public class CItemStatus
{
    public string statusName = string.Empty;
    public int statusValue = 0;
}

/// <summary>
/// 조합 레시피 클래스
/// </summary>
[System.Serializable]
public class CCraftRecipe
{
    // 조합에 필요한 아이템의 ID
    public int[] requiredItems = null;

    // 조합후 반환될 아이템의 ID
    public int itemToCraft = 0;

    public CCraftRecipe(int itemToCraft, int[] requiredItems)
    {
        this.itemToCraft = itemToCraft;
        this.requiredItems = requiredItems;
    }

    public CCraftRecipe()
    {
        itemToCraft = 0;
        requiredItems = new int[9];
    }
}

