using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeerProjectile : MonoBehaviour
{
    private float _beerVolume;

    public delegate void BeerBroken(GameObject beer);
    public static event BeerBroken OnBeerBroken = delegate { };

    public float BeerVolume
    {
        get
        {
            return _beerVolume;
        }
        set
        {
            _beerVolume = value;
        }
    }

    private void Start()
    {
        BeerThrow.OnBeerThrown += ScaleBeer;
    }

    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.CompareTag("Borders"))
        {
            Destroy(gameObject);
            OnBeerBroken(gameObject);
        }
    }

    private void ScaleBeer(GameObject beer)
    {
        transform.localScale = beer.transform.localScale;
    }

    private void OnDisable()
    {
        BeerThrow.OnBeerThrown -= ScaleBeer;
    }
}
