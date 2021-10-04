using UnityEngine;

public class BatyaBeerCatching : MonoBehaviour
{
    private bool _isBeerCatchingAllowed;

    public delegate void BeerCaught(GameObject beer);
    public static event BeerCaught OnBeerCaught = delegate { };

    private void Start()
    {
        AllowBeerCatching();
        BatyaMouth.OnMouthOpened += AllowBeerCatching;;
        BatyaMouth.OnMouthClosed += BanBeerCatching;
    }

    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (_isBeerCatchingAllowed)
        {
            if (collider2D.CompareTag("BeerProjectile"))
            {
                var beerGameObject = collider2D.gameObject;
                OnBeerCaught(beerGameObject);
                Destroy(beerGameObject);
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
