using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeerInHand : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;

    private void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        DisableBeerIcon();
        BeerPickUp.OnBeerPickedInHand += EnableBeerIcon;
        BeerThrow.OnBeerThrown += DisableBeerIcon;
    }

    private void EnableBeerIcon()
    {
        _spriteRenderer.enabled = true;
    }

    private void DisableBeerIcon()
    {
        _spriteRenderer.enabled = false;
    }

    private void OnDisable()
    {
        BeerPickUp.OnBeerPickedInHand -= EnableBeerIcon;
        BeerThrow.OnBeerThrown -= DisableBeerIcon;
    }
}
