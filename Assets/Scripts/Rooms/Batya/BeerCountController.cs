using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeerCountController : MonoBehaviour
{
    [SerializeField] private Transform _allBeerContainer;

    private float _currentBeerVolume;

    private int _totalBeerBottlesAmount;
    private int _destroyedBeerBottlesAmount;

    public delegate void AllBeerDestroyed();
    public static event AllBeerDestroyed OnAllBeerDestroyed = delegate { };

    public delegate void BeerVolumeIncreased(float currentBeerVolume);
    public static event BeerVolumeIncreased OnBeerVolumeIncreased = delegate { };

    private void Start()
    {
        _destroyedBeerBottlesAmount = 0;
        _totalBeerBottlesAmount = _allBeerContainer.childCount;
        BeerProjectile.OnBeerBroken += IncreaseDestroyedBeerBottlesAmount;
        BeerProjectile.OnBeerBroken += CheckIsAllBeerBottlesDestroyed;
        BatyaBeerCatching.OnBeerCaught += IncreaseCurrentBeerVolume;
    }

    private void IncreaseDestroyedBeerBottlesAmount(GameObject beer)
    {
        _destroyedBeerBottlesAmount++;
    }

    private void CheckIsAllBeerBottlesDestroyed(GameObject beer)
    {
        if (_destroyedBeerBottlesAmount >= _totalBeerBottlesAmount)
        {
            OnAllBeerDestroyed();
        }
    }

    private void IncreaseCurrentBeerVolume(GameObject beer)
    {
        var beerProjectile = beer.GetComponent<BeerProjectile>();
        _currentBeerVolume += beerProjectile.BeerVolume;
        OnBeerVolumeIncreased(_currentBeerVolume);
    }

    private void OnDisable()
    {
        BeerProjectile.OnBeerBroken -= IncreaseDestroyedBeerBottlesAmount;
        BeerProjectile.OnBeerBroken -= CheckIsAllBeerBottlesDestroyed;
    }
}
