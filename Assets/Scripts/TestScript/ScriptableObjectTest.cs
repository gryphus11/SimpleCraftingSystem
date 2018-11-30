using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScriptableObjectTest : MonoBehaviour
{
    [SerializeField]
    private Text _dataName = null;

    [SerializeField]
    private Text _dataDesc = null;

    private int _dbIndex = 0;
    private CItem[] _items = null;

    // Use this for initialization
    void Start()
    {
        CItemDatabase itemDb = Resources.Load<CItemDatabase>("Database/ItemDatabase");

        _items = itemDb.GetItemArray();

        foreach (CItem item in _items)
        {
            Debug.Log(item.title);
        }
    }

    public void OnNextClick()
    {
        if (_items != null)
        {
            ++_dbIndex;
            if (_dbIndex >= _items.Length)
            {
                _dbIndex = 0;
            }

            _dataName.text = _items[_dbIndex].title;
            _dataDesc.text = _items[_dbIndex].description;
        }
    }

    public void OnPrevClick()
    {
        if (_items != null)
        {
            --_dbIndex;
            if (_dbIndex < 0)
            {
                _dbIndex = _items.Length - 1;
            }

            _dataName.text = _items[_dbIndex].title;
            _dataDesc.text = _items[_dbIndex].description;
        }
    }

}
