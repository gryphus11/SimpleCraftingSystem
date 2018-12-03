using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CCraftingSlots : MonoBehaviour
{
    [SerializeField]
    private CCraftRecipeDatabase _recipeDatabase = null;

    private List<CUIItem> _uiItems = new List<CUIItem>();

    [SerializeField]
    private CUIItem _craftResultSlot = null;

    // Use this for initialization
    void Start()
    {
        _uiItems = GetComponent<CSlotPanel>().uiItems;
        _uiItems.ForEach(item => item.isCraftingSlot = true);

        if (_recipeDatabase == null)
        {
            _recipeDatabase = CAssetBundleManager.GetRecipeDatabase();
        }
    }

    public void UpdateRecipe()
    {
        Debug.Log("####CCraftingSlots::UpdateRecipe");
        int[] itemTable = new int[_uiItems.Count];

        for (int i = 0; i < _uiItems.Count; ++i)
        {
            if (_uiItems[i].item != null)
            {
                itemTable[i] = _uiItems[i].item.id;
            }
        }

        CItem itemToCraft = _recipeDatabase.CheckRecipe(itemTable);
        UpdateCraftingResultSlot(itemToCraft);
    }

    private void UpdateCraftingResultSlot(CItem itemToCraft)
    {
        _craftResultSlot.UpdateItem(itemToCraft);
    }
}
