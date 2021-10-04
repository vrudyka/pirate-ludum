using System;
using UnityEngine;

public class BatyaChasing : MonoBehaviour
{
    [SerializeField] private GameObject _cursor;
    [SerializeField] private float _chasingSpeed = 0;
    [SerializeField] private Character _character;
    private Transform _characterTransform;
    private bool _isCanChase = false;

    private void Start()
    {
        _characterTransform = FindObjectOfType<Character>().transform;
        BeerCountController.OnAllBeerDestroyed += BanChasing;
        Dialog.OnDialogStarted += BanChasing;
        Dialog.OnDialogEnded += AllowChasing;
    }

    private void FixedUpdate()
    {
        _cursor.transform.position = _character.mousePos;

        if (_isCanChase)
        {
            if (_characterTransform != null)
            {
                Vector3 chaseDirection = new Vector3(_characterTransform.position.x, _characterTransform.position.y,
                    transform.position.z);
                transform.position =
                    Vector3.MoveTowards(transform.position, chaseDirection, _chasingSpeed * Time.deltaTime);
            }
        }
    }

    private void AllowChasing()
    {
        _isCanChase = true;
    }

    private void BanChasing()
    {
        _isCanChase = false;
    }

    private void OnDisable()
    {
        Dialog.OnDialogStarted -= BanChasing;
        Dialog.OnDialogEnded += AllowChasing;
        BeerCountController.OnAllBeerDestroyed -= BanChasing;
    }
}
