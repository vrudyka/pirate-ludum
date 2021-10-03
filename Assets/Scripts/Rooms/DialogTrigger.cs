using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger : MonoBehaviour
{
    [SerializeField] private Dialog _dialogToStart;
    private bool _isTriggerCanBeUsed;

    private void Start()
    {
        AllowTriggerUsing();
    }

    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (_isTriggerCanBeUsed)
        {
            if (collider2D.CompareTag("Player"))
            {
                _dialogToStart.StartDialog();
                gameObject.SetActive(false);
            }
        }
    }

    private void AllowTriggerUsing()
    {
        _isTriggerCanBeUsed = true;
    }

    private void BanTriggerUsing()
    {
        _isTriggerCanBeUsed = false;
    }
}
