using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System.IO;

public class CCreateAssetBundles
{
    [MenuItem("Bundles/Build Asset Bundles")]
    static void BuildAllAssetBundles()
    {
        string assetBundleDirectory = CUtillity.assetBundlePath;

        if (!Directory.Exists(assetBundleDirectory))
        {
            Directory.CreateDirectory(assetBundleDirectory);
        }

        BuildPipeline.BuildAssetBundles(assetBundleDirectory, BuildAssetBundleOptions.ChunkBasedCompression, BuildTarget.StandaloneWindows);
    }

    [MenuItem("Bundles/Unload Asset Bundles")]
    static void UnloadAllAssetBundles()
    {
        AssetBundle.UnloadAllAssetBundles(true);
    }
}
