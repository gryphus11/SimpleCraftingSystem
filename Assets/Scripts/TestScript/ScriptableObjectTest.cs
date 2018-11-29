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

    private CItemDatabase _itemDb = null;
    private int _dbIndex = 0;

    // Use this for initialization
    void Start()
    {
        _itemDb = Resources.Load<CItemDatabase>("Database/ItemDatabase");

        foreach (CItem item in _itemDb.items)
        {
            Debug.Log(item.title);
        }
    }

    public void OnNextClick()
    {
        if (_itemDb != null)
        {
            ++_dbIndex;
            if (_dbIndex >= _itemDb.items.Count)
            {
                _dbIndex = 0;
            }

            _dataName.text = _itemDb.items[_dbIndex].title;
            _dataDesc.text = _itemDb.items[_dbIndex].description;
        }
    }

    public void OnPrevClick()
    {
        if (_itemDb != null)
        {
            --_dbIndex;
            if (_dbIndex < 0)
            {
                _dbIndex = _itemDb.items.Count - 1;
            }

            _dataName.text = _itemDb.items[_dbIndex].title;
            _dataDesc.text = _itemDb.items[_dbIndex].description;
        }
    }

}
