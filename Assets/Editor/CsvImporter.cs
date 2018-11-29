using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public class CsvImporter : AssetPostprocessor
{
    static void OnPostprocessAllAssets(string[] importedAssets, string[] deletedAssets, string[] movedAssets, string[] movedFromAssetPaths)
    {
        string targetFile = "Assets/Table/ItemDatabase.csv";
        string exportFile = "Assets/Table/ItemDatabase.asset";

        foreach (string asset in importedAssets)
        {
            if (!targetFile.Equals(asset))
            {
                continue;
            }

            CItemDatabase itemDatabase = AssetDatabase.LoadAssetAtPath<CItemDatabase>(exportFile);

            if (itemDatabase == null)
            {
                itemDatabase = ScriptableObject.CreateInstance<CItemDatabase>();
                AssetDatabase.CreateAsset((ScriptableObject)itemDatabase, exportFile);
            }

            itemDatabase.items.Clear();

            using (StreamReader reader = new StreamReader(targetFile))
            {
                // 헤더 건너뜀
                reader.ReadLine();
                reader.ReadLine();

                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    string[] dataStrs = line.Trim().Split('"',',');

                    foreach (string str in dataStrs)
                    {
                        Debug.Log(str);
                    }
                    Debug.Log("LineEnd");
                }
            }
        }
    }
}
