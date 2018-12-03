using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class CItemDatabase : ScriptableObject
{
    [SerializeField]
    private List<CItem> items = new List<CItem>();

#if UNITY_EDITOR

    static string targetFile = CUtillity.tableImportPath + "ItemTable.csv";
    static string exportFile = CUtillity.databaseExportPath + "ItemDatabase.asset";

    [UnityEditor.MenuItem("Database/Create ItemDatabase")]
    public static void UpdateDatabase()
    {
        if (!Directory.Exists(CUtillity.databaseExportPath))
        {
            Directory.CreateDirectory(CUtillity.databaseExportPath);
        }

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
                Debug.Log(dataStrings[index]);
                item.iconPath = dataStrings[index++];
                for (int i = index; i < dataStrings.Length; ++i)
                {
                    string[] statusData = dataStrings[i].Split(new char[] { '=' }, System.StringSplitOptions.RemoveEmptyEntries);
                    CItemStatus stat = new CItemStatus();
                    stat.statusName = statusData[0];
                    int.TryParse(statusData[1], out stat.statusValue);
                    item.status.Add(stat);
                }

                itemDatabase.items.Add(item);
            }
        }

        UnityEditor.AssetDatabase.SaveAssets();

        for (int i = 0; i < itemDatabase.items.Count; ++i)
        {
            List<CItemStatus> stats = itemDatabase.items[i].status;

            System.Text.StringBuilder builder = new System.Text.StringBuilder();
            foreach (CItemStatus stat in stats)
            {
                builder.Append(stat.statusName + " " + stat.statusValue + "\n");
            }

            Debug.Log(builder.ToString());
        }
        Debug.Log("Updated");
    }
#endif

    public CItem GetItem(int id)
    {
        return items.Find(item => item.id == id);
    }

    public CItem GetItem(string title)
    {
        return items.Find(item => item.title.Equals(title));
    }

    public CItem[] GetItemArray()
    {
        return items.ToArray();
    }
}
