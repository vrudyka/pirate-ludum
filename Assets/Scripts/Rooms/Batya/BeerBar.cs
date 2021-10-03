using UnityEngine;
using UnityEngine.UI;

public class BeerBar : MonoBehaviour
{
    [SerializeField] private Image _beerBarImage;

    private void Start()
    {
        BeerCountController.OnBeerVolumeIncreased += SetUpHealBar;
        _beerBarImage.fillAmount = 0;
    }

    private void SetUpHealBar(float currentBeerVolume)
    {
        var beerValue = currentBeerVolume / 100f;
        _beerBarImage.fillAmount = beerValue;
        SetBeerBarColor(beerValue);
    }

    private void SetBeerBarColor(float beerValue)
    {
        var color = Color.clear;

        if (beerValue <= 0.39f)
        {
            color = Color.yellow;
        }
        else if (beerValue <= 0.53f)
        {
            color = Color.green;
        }
        else
        {
            color = Color.red;
        }

        _beerBarImage.color = color;
    }

    private void OnDisable()
    {
        BeerCountController.OnBeerVolumeIncreased -= SetUpHealBar;
    }
}
