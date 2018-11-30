using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

[CreateAssetMenu(fileName = "ItemDatabase.asset", menuName = "Create Asset Database")]
public class CItemDatabase : ScriptableObject
{
    [SerializeField]
    private List<CItem> items = new List<CItem>();

#if UNITY_EDITOR

    string targetFile = CUtillity.tableImportPath + "ItemTable.csv";
    string exportFile = CUtillity.databaseExportPath + "ItemDatabase.asset";

    [ContextMenu("데이터베이스 갱신")]
    public void UpdateDatabase()
    {
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
                item.icon = Resources.Load<Sprite>("Sprites/" + dataStrings[index++]);
                for (int i = index; i < dataStrings.Length; ++i)
                {
                    string[] statusData = dataStrings[i].Split(new char[] { '=' }, System.StringSplitOptions.RemoveEmptyEntries);
                    item.status.Add(statusData[0], int.Parse(statusData[1]));
                }

                itemDatabase.items.Add(item);
            }
        }
        UnityEditor.AssetDatabase.SaveAssets();

        for (int i = 0; i < itemDatabase.items.Count; ++i)
        {
            Dictionary<string, int> stats = itemDatabase.items[i].status;

            System.Text.StringBuilder builder = new System.Text.StringBuilder();
            foreach (string key in stats.Keys)
            {
                builder.Append(key + " " + stats[key] + "\n");
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
