using Assets.Scripts.Rooms.Batya.Beer;
using UnityEngine;

public class RandomBeerSpawner : MonoBehaviour
{
    [SerializeField] private int _beerBottlesAmount;
    [SerializeField] private Beer _beerPrefab;
    [SerializeField] private Vector2 _leftUpExtremePoint;
    [SerializeField] private Vector2 _rightDownExtremePoint;

    private void Start()
    {
        SpawnBeer();
    }

    private void SpawnBeer()
    {
        for (var bottleIndex = 0; bottleIndex <= _beerBottlesAmount; bottleIndex++)
        {
            var beerSpawnPoint = GetRandomSpawnPosition();
            var beer = Instantiate(_beerPrefab, beerSpawnPoint, Quaternion.identity, transform);
            beer.gameObject.SetActive(false);
            beer.RandomlyInitializeBeer();
            beer.gameObject.SetActive(true);
        }
    }

    private Vector3 GetRandomSpawnPosition()
    {
        var minXPoint = _leftUpExtremePoint.x;
        var maxXPoint = _rightDownExtremePoint.x;
        var randomXPoint = Random.Range(minXPoint, maxXPoint);

        var minYPoint = _rightDownExtremePoint.y;
        var maxYPoint = _leftUpExtremePoint.y;
        var randomYPoint = Random.Range(minYPoint, maxYPoint);

        var beerHeightAboveMap = -3f;
        return new Vector3(randomXPoint, randomYPoint, beerHeightAboveMap);
    }
}
