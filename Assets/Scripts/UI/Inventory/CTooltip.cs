using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CTooltip : MonoBehaviour
{

    private Text _tooltipText = null;

    private void Start()
    {
        _tooltipText = GetComponentInChildren<Text>();
    }

    public void GenerateToolTip(CItem item)
    {
        System.Text.StringBuilder statusBuilder = new System.Text.StringBuilder();

        //Debug.Log(item.status.Count);
        foreach (CItemStatus pair in item.status)
        {
            statusBuilder.Append(pair.statusName + " : " + pair.statusValue + "\n");
        }

        System.Text.StringBuilder tooltipBuilder = new System.Text.StringBuilder();
        tooltipBuilder.AppendFormat("<b>{0}</b>\n{1}\n\n<b>{2}</b>", item.title, item.description, statusBuilder.ToString());
        _tooltipText.text = tooltipBuilder.ToString();
        gameObject.SetActive(true);
    }

}
