using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;

[CreateAssetMenu(fileName = "RecipeDatabase.asset", menuName = "Create Recipe Database")]
public class CCraftRecipeDatabase : ScriptableObject
{
    public List<CCraftRecipe> recipes = new List<CCraftRecipe>();

    [SerializeField]
    private CItemDatabase itemDb = null;

#if UNITY_EDITOR
    string targetFile = "Assets/Table/RecipeTable.csv";
    string exportFile = "Assets/Resources/Database/RecipeDatabase.asset";

    [ContextMenu("데이터베이스 갱신")]
    public void UpdateDatabase()
    {
        CCraftRecipeDatabase recipeDatabase = UnityEditor.AssetDatabase.LoadAssetAtPath<CCraftRecipeDatabase>(exportFile);

        if (recipeDatabase == null)
        {
            recipeDatabase = ScriptableObject.CreateInstance<CCraftRecipeDatabase>();
            UnityEditor.AssetDatabase.CreateAsset((ScriptableObject)recipeDatabase, exportFile);
        }

        recipeDatabase.recipes.Clear();

        using (StreamReader reader = new StreamReader(targetFile))
        {
            // 헤더 건너뜀
            reader.ReadLine();
            reader.ReadLine();

            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                string[] dataStrings = line.Trim().Split(new char[] { ',' }, System.StringSplitOptions.RemoveEmptyEntries);

                int index = 0;

                CCraftRecipe recipe = new CCraftRecipe();
                int.TryParse(dataStrings[index++], out recipe.itemToCraft);

                for (int i = index; i < dataStrings.Length; ++i)
                {
                    int.TryParse(dataStrings[i], out recipe.requiredItems[i-1]);
                }

                recipeDatabase.recipes.Add(recipe);
            }
        }

        UnityEditor.AssetDatabase.SaveAssets();

        Debug.Log("Updated");
    }
#endif

    /// <summary>
    /// 레시피를 체크하여 일치하면 아이템 데이터를 반환
    /// </summary>
    /// <param name="recipe"></param>
    /// <returns></returns>
    public CItem CheckRecipe(int[] recipe)
    {
        if (itemDb == null)
        {
            return null;
        }

        foreach (CCraftRecipe craftRecipe in recipes)
        {
            if (craftRecipe.requiredItems.SequenceEqual(recipe))
            {
                return itemDb.GetItem(craftRecipe.itemToCraft);
            }
        }

        return null;
    }
}
