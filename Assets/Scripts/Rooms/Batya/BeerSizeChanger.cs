using UnityEngine;
using Random = UnityEngine.Random;

public class BeerSizeChanger : MonoBehaviour
{
    [SerializeField] private int _minBeerVolume;
    [SerializeField] private int _maxBeerVolume;
    [SerializeField] private Vector3 _minBeerScale;
    [SerializeField] private Vector3 _maxBeerScale;
    [SerializeField] private float _scalingRate;

    private float _beerVolume;
    private bool _isBeerSizeCanBeChanged;

    private void Start()
    {
        SetupBeerVolume();
        AllowBeerSizeChanging();
        BeerPickUp.OnBeerPickedInHand += BanBeerSizeChanging;
        BeerProjectile.OnBeerBroken += AllowBeerSizeChanging;
        BatyaBeerCatching.OnBeerCaught += AllowBeerSizeChanging;
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
            else if (Input.GetMouseButtonUp(0) || Input.GetMouseButtonUp(1))
            {
                SetupBeerVolume();
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

    private void SetupBeerVolume()
    {
        var currentScale = transform.localScale;
        _beerVolume = ScaleToVolumeConverter.VolumeFromXScaleValue(currentScale.x);
    }

    private void AllowBeerSizeChanging(GameObject beer)
    {
        _isBeerSizeCanBeChanged = true;
    }

    private void AllowBeerSizeChanging()
    {
        _isBeerSizeCanBeChanged = true;
    }

    private void BanBeerSizeChanging(GameObject beer)
    {
        _isBeerSizeCanBeChanged = false;
    }

    private void OnDisable()
    {
        BeerPickUp.OnBeerPickedInHand -= BanBeerSizeChanging;
        BeerProjectile.OnBeerBroken -= AllowBeerSizeChanging;
        BatyaBeerCatching.OnBeerCaught -= AllowBeerSizeChanging;
    }
}
