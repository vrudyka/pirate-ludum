using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeerSizeChanger : MonoBehaviour
{
    [SerializeField] private int _minBeerVolume;
    [SerializeField] private int _maxBeerVolume;
    [SerializeField] private Vector3 _minBeerScale;
    [SerializeField] private Vector3 _maxBeerScale;
    [SerializeField] private float _scalingRate;

    private bool _isBeerSizeCanBeChanged;

    private void Start()
    {
        AllowBeerSizeChanging();
        BeerPickUp.OnBeerPickedInHand += BanBeerSizeChanging;
    }

    private void OnMouseOver()
    {
        if (_isBeerSizeCanBeChanged)
        {
            if (Input.GetMouseButton(0))
            {
                ScaleBeerUpRoutine();
            }
            else if (Input.GetMouseButton(1))
            {
                ScaleBeerDownRoutine();
            }
        }
    }

    private int GetRandomBeerVolume()
    {
        var randomBeerVolume = Random.Range(_minBeerVolume, _maxBeerVolume);

        return randomBeerVolume;
    }

    private void ScaleBeerUpRoutine()
    {
        transform.localScale = Vector3.Lerp(transform.localScale, _maxBeerScale, _scalingRate * Time.deltaTime);
    }

    private void ScaleBeerDownRoutine()
    {
        transform.localScale = Vector3.Lerp(transform.localScale, _minBeerScale, _scalingRate * Time.deltaTime);
    }

    private void AllowBeerSizeChanging()
    {
        _isBeerSizeCanBeChanged = true;
    }

    private void BanBeerSizeChanging()
    {
        _isBeerSizeCanBeChanged = false;
    }

    private void OnDisable()
    {
        BeerPickUp.OnBeerPickedInHand -= BanBeerSizeChanging;
    }
}
