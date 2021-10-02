using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldingObject : MonoBehaviour
{
    public HoldingObjectType type;
    public GameObject Highlight;

    public void SetHighlight(bool isActive)
    {
        if (Highlight == null)
            return;

        Highlight.SetActive(isActive);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var holdingObj = collision.gameObject.GetComponent<HoldingObject>();
        if (holdingObj == null)
            return;

        //Debug.Log($"{type} and {holdingObj.type}");
    }
}

public enum HoldingObjectType
{
    Bowl,
    Sir,
    Salt,
    Egg,
    Sugar,
    Fork,
    Masher,
    Fire,
    Pan,
    Switch
}