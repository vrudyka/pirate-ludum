using UnityEngine;

public class BeerPickUp : MonoBehaviour
{
    private bool _isCanPickBeer;

    public delegate void BeerPickedInHand(GameObject beer);
    public static event BeerPickedInHand OnBeerPickedInHand = delegate { };

    private void Start()
    {
        AllowBeerPicking();
        BatyaBeerCatching.OnBeerCaught += AllowBeerPicking;
        BeerProjectile.OnBeerBroken += AllowBeerPicking;
    }

    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (_isCanPickBeer)
        {
            if (collider2D.CompareTag("Beer"))
            {
                Destroy(collider2D.gameObject);
                BanBeerPicking();
                OnBeerPickedInHand(collider2D.gameObject);
            }
        }
    }

    private void AllowBeerPicking(GameObject beer)
    {
        _isCanPickBeer = true;
    }

    private void AllowBeerPicking()
    {
        _isCanPickBeer = true;
    }

    private void BanBeerPicking()
    {
        _isCanPickBeer = false;
    }

    private void OnDisable()
    {
        BatyaBeerCatching.OnBeerCaught -= AllowBeerPicking;
        BeerProjectile.OnBeerBroken -= AllowBeerPicking;
    }
}
