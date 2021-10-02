using UnityEngine;

namespace Assets.Scripts.Rooms.Batya.Beer
{
    public class Beer : MonoBehaviour
    {
        [SerializeField] private int _minBeerVolume;
        [SerializeField] private int _maxBeerVolume;
        [SerializeField] private Vector3 _minBeerScale;
        [SerializeField] private Vector3 _maxBeerScale;
        [SerializeField] private float _scaleModifier;

        public void RandomlyInitializeBeer()
        {
            var beerVolume = GetRandomBeerVolume();
            ScaleBeerAccordingToVolume(beerVolume);
            RandomlyRotateBeer();
        }

        private void ScaleBeerAccordingToVolume(int beerVolume)
        {
            var beerScale = transform.localScale;
            var modifiedVolumeMultiplier = beerVolume * _scaleModifier;
            var newBeerScale = new Vector3(beerScale.x * modifiedVolumeMultiplier, beerScale.y * modifiedVolumeMultiplier, beerScale.z);
            transform.localScale = newBeerScale;
        }

        private void RandomlyRotateBeer()
        {
            var randomZAngle = Random.Range(0f, 360f);
            transform.Rotate(0, 0, randomZAngle);
        }

        private int GetRandomBeerVolume()
        {
            var randomBeerVolume = Random.Range(_minBeerVolume, _maxBeerVolume);

            return randomBeerVolume;
        }
    }
}
