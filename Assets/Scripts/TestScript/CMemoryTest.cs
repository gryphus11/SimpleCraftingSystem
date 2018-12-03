using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CMemoryTest : MonoBehaviour
{
    List<CItemDatabase> datList = new List<CItemDatabase>();
    List<Sprite> sprList = new List<Sprite>();

    private void Start()
    {
        StartCoroutine(LoadBundleCoroutine());
    }

    IEnumerator LoadBundleCoroutine()
    {
        while (true)
        {
            bool isAddable = true;
            CItemDatabase data = CAssetBundleManager.GetItemDatabase();
            Sprite sprite = CAssetBundleManager.GetUISprite("ore_diamond");

            //foreach (CItemDatabase dat in datList)
            //{
            //    if (dat.Equals(data))
            //    {
            //        isAddable = false;
            //        break;
            //    }
            //}

            if (isAddable)
            {
                Debug.Log("데이터넣음");
                datList.Add(data);
            }

            isAddable = true;

            foreach (Sprite spr in sprList)
            {
                if (spr.Equals(sprite))
                {
                    isAddable = false;
                    break;
                }
            }

            if (isAddable)
            {
                Debug.Log("데이터넣음");
                sprList.Add(sprite);
            }

                yield return null;
        }
    }
}
