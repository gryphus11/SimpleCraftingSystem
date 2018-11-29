using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptableObjectTest : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        CItemDatabase itemDb = Resources.Load<CItemDatabase>("Database/ItemDatabase");

        foreach (CItem item in itemDb.items)
        {
            Debug.Log(item.title);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
