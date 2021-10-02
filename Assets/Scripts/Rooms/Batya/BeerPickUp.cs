using Assets.Scripts.Rooms.Batya.Beer;
using UnityEngine;

public class BeerPickUp : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        var beer = collider2D.GetComponent<Beer>();

        if (beer != null)
        {
            beer.DestroyBeer();
        }
    }
}
