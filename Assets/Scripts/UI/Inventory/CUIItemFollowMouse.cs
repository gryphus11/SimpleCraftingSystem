using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CUIItemFollowMouse : MonoBehaviour
{
    private void LateUpdate()
    {
        transform.position = Input.mousePosition;
    }
}
