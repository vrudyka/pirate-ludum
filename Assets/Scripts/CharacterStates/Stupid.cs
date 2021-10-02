using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stupid : AbstractCharacterAction
{
    public override void UpdateAction()
    {
        Debug.Log($"Stupid doing stuff");
    }
}
