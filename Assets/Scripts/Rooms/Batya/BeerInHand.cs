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
        BeerPickUp.OnBeerPickedInHand += ScaleBeer;
        BeerThrow.OnBeerThrown += DisableBeerIcon;
    }

    private void ScaleBeer(GameObject beer)
    {
        transform.localScale = beer.transform.localScale;
    }

    private void EnableBeerIcon(GameObject beer)
    {
        _spriteRenderer.enabled = true;
    }

    private void DisableBeerIcon(GameObject beer)
    {
        _spriteRenderer.enabled = false;
    }

    private void DisableBeerIcon()
    {
        _spriteRenderer.enabled = false;
    }

    private void OnDisable()
    {
        BeerPickUp.OnBeerPickedInHand -= EnableBeerIcon;
        BeerPickUp.OnBeerPickedInHand -= ScaleBeer;
        BeerThrow.OnBeerThrown -= DisableBeerIcon;
    }
}
