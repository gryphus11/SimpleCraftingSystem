using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[CreateAssetMenu(fileName = "ItemDatabase.asset", menuName = "Create Asset Database")]
public class CItemDatabase : ScriptableObject
{
    public List<CItem> items = new List<CItem>();

#if UNITY_EDITOR
    [ContextMenu("데이터베이스 갱신")]
    public void UpdateDatabase()
    {
        string targetFile = "Assets/Table/ItemTable.csv";
        string exportFile = "Assets/Resources/Database/ItemDatabase.asset";

        CItemDatabase itemDatabase = UnityEditor.AssetDatabase.LoadAssetAtPath<CItemDatabase>(exportFile);

        if (itemDatabase == null)
        {
            itemDatabase = ScriptableObject.CreateInstance<CItemDatabase>();
            UnityEditor.AssetDatabase.CreateAsset((ScriptableObject)itemDatabase, exportFile);
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
                string[] dataStrings = line.Trim().Split(new char[] { '"', ',' }, System.StringSplitOptions.RemoveEmptyEntries);

                int index = 0;

                CItem item = new CItem();
                int.TryParse(dataStrings[index++], out item.id);
                item.title = dataStrings[index++];
                item.description = dataStrings[index++];
                item.icon = UnityEditor.AssetDatabase.LoadAssetAtPath<Sprite>(dataStrings[index++]);
                for (int i = index; i < dataStrings.Length; ++i)
                {
                    string[] statusData = dataStrings[i].Split(new char[] { '=' }, System.StringSplitOptions.RemoveEmptyEntries);
                    item.status.Add(statusData[0], int.Parse(statusData[1]));
                }

                itemDatabase.items.Add(item);
            }
        }

        UnityEditor.AssetDatabase.SaveAssets();
        Debug.Log("Updated");
    }
#endif
}
