using UnityEngine;

public class BeerThrow : MonoBehaviour
{
    [SerializeField] private GameObject _throwableBeerPrefab;
    [SerializeField] private float _throwForce;

    private Rigidbody2D _rigidbody2D;
    private bool _isBeerCanBeThrown;
    private Camera _camera;

    public delegate void BeerThrown();

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
                OnBeerThrown();
            }
        }
    }

    private void ThrowBeer(Vector3 mousePosition)
    {
        var mousePositionInWorldPoints = _camera.ScreenToWorldPoint(mousePosition);
        var mousePositionWithCharacterZ = new Vector3(mousePositionInWorldPoints.x, mousePositionInWorldPoints.y, transform.position.z);
        var throwDirection = (mousePositionWithCharacterZ - transform.position).normalized;
        var beer = Instantiate(_throwableBeerPrefab, transform.position, Quaternion.identity);
        var beerRigidBody2d = beer.GetComponent<Rigidbody2D>(); 
        beerRigidBody2d.AddForce(throwDirection * _throwForce, ForceMode2D.Impulse);
    }

    private void AllowBeerThrowing()
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
