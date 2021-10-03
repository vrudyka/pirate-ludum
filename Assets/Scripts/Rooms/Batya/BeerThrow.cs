using UnityEngine;

public class BeerThrow : MonoBehaviour
{
    [SerializeField] private GameObject _throwableBeerPrefab;
    [SerializeField] private GameObject _beerInHand;
    [SerializeField] private float _throwForce;

    private Rigidbody2D _rigidbody2D;
    private bool _isBeerCanBeThrown;
    private Camera _camera;

    public delegate void BeerThrown(GameObject beer);
    public static event BeerThrown OnBeerThrown = delegate { };

    private void Start()
    {
        _camera = Camera.main;
        BanBeerThrowing();
        BeerPickUp.OnBeerPickedInHand += AllowBeerThrowing;
    }

    private void Update()
    {
        if (_isBeerCanBeThrown)
        {
            if (Input.GetMouseButton(0))
            {
                ThrowBeer(Input.mousePosition);
                BanBeerThrowing();
            }
        }
    }

    private void ThrowBeer(Vector3 mousePosition)
    {
        var mousePositionInWorldPoints = _camera.ScreenToWorldPoint(mousePosition);
        var mousePositionWithCharacterZ = new Vector3(mousePositionInWorldPoints.x, mousePositionInWorldPoints.y, transform.position.z);
        var throwDirection = (mousePositionWithCharacterZ - transform.position).normalized;
        var beer = Instantiate(_throwableBeerPrefab, transform.position, Quaternion.identity);
        beer.transform.localScale = _beerInHand.transform.localScale;
        var beerProjectileComponent = beer.GetComponent<BeerProjectile>();
        beerProjectileComponent.BeerVolume = ScaleToVolumeConverter.VolumeFromXScaleValue(beer.transform.localScale.x);
        var beerRigidBody2d = beer.GetComponent<Rigidbody2D>(); 
        beerRigidBody2d.AddForce(throwDirection * _throwForce, ForceMode2D.Impulse);

        OnBeerThrown(beer);
    }

    private void AllowBeerThrowing(GameObject beer)
    {
        _isBeerCanBeThrown = true;
    }

    private void BanBeerThrowing()
    {
        _isBeerCanBeThrown = false;
    }

    private void OnDisable()
    {
        BeerPickUp.OnBeerPickedInHand -= AllowBeerThrowing;
    }
}
