using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CAssetBundleManager
{
    private static CAssetBundleManager _instance = null;
    private AssetBundle _ui = null;
    private AssetBundle _database = null;

    private CAssetBundleManager()
    {

    }

    public static Sprite GetUISprite(string fileName)
    {
        InitCheck();

        return _instance._ui.LoadAsset<Sprite>(fileName);
    }

    public static CItemDatabase GetItemDatabase()
    {
        InitCheck();

        return _instance._database.LoadAsset<CItemDatabase>("ItemDatabase");
    }

    public static CCraftRecipeDatabase GetRecipeDatabase()
    {
        InitCheck();

        return _instance._database.LoadAsset<CCraftRecipeDatabase>("RecipeDatabase");
    }

    private static void InitCheck()
    {
        if (_instance == null)
        {
            _instance = new CAssetBundleManager();
            _instance._ui = AssetBundle.LoadFromFile(CUtillity.assetBundlePath + "ui");
            _instance._database = AssetBundle.LoadFromFile(CUtillity.assetBundlePath + "database");
            return;
        }
    }
}
