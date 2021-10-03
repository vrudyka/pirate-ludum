using UnityEngine;

public class BatyaChasing : MonoBehaviour
{
    [SerializeField] private float _chasingSpeed = 0;
    private Transform _characterTransform;

    private void Start()
    {
        _characterTransform = FindObjectOfType<Character>().transform;
    }

    private void FixedUpdate()
    {
        if (_characterTransform != null)
        {
            Vector3 chaseDirection = new Vector3(_characterTransform.position.x, _characterTransform.position.y, transform.position.z);
            transform.position = Vector3.MoveTowards(transform.position, chaseDirection, _chasingSpeed * Time.deltaTime);
        }
    }
}
