using UnityEngine;

public class BeerPickUp : MonoBehaviour
{
    private bool _isCanPickBeer;

    public delegate void BeerPickedInHand();
    public static event BeerPickedInHand OnBeerPickedInHand = delegate { };

    private void Start()
    {
        AllowBeerPicking();
        BatyaBeerCatching.OnBeerCaught += AllowBeerPicking;
    }

    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (_isCanPickBeer)
        {
            if (collider2D.CompareTag("Beer"))
            {
                Destroy(collider2D.gameObject);
                BanBeerPicking();
                OnBeerPickedInHand();
            }
        }
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
    }
}
