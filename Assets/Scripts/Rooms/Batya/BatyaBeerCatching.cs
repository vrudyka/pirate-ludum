using System.Collections;
using System.Collections.Generic;
using UnityEditor.IMGUI.Controls;
using UnityEngine;

public class BatyaBeerCatching : MonoBehaviour
{
    private bool _isBeerCatchingAllowed;

    public delegate void BeerCaught();
    public static event BeerCaught OnBeerCaught = delegate { };

    private void Start()
    {
        AllowBeerCatching();
        BatyaMouth.OnMouthOpened += AllowBeerCatching;;
        BatyaMouth.OnMouthClosed += BanBeerCatching;
    }

    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        Debug.LogError(collider2D.tag);

        if (_isBeerCatchingAllowed)
        {
            if (collider2D.CompareTag("BeerProjectile"))
            {
                Destroy(collider2D.gameObject);
                OnBeerCaught();
            }
        }
    }

    private void AllowBeerCatching()
    {
        _isBeerCatchingAllowed = true;
    }

    private void BanBeerCatching()
    {
        _isBeerCatchingAllowed = false;
    }

    private void OnDisable()
    {
        BatyaMouth.OnMouthOpened -= AllowBeerCatching;;
        BatyaMouth.OnMouthClosed -= BanBeerCatching;
    }
}
