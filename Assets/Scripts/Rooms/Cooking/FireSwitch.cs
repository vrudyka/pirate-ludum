using System;
using UnityEngine;

public class FireSwitch : MonoBehaviour
{
    public event Action switched;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Character")
        {
            switched?.Invoke();
        }
    }
}
