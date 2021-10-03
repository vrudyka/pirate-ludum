using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatyaCharacterCatching : MonoBehaviour
{
    public delegate void PlayerCaught();
    public static event PlayerCaught OnPlayerCaught = delegate { };

    private void OnCollisionEnter2D(Collision2D collision2D)
    {
        var collidedGameObject = collision2D.gameObject;

        if (collidedGameObject.CompareTag("Player"))
        {
            Destroy(collidedGameObject);
            SceneController.Instance.ReloadCurrentScene();
            OnPlayerCaught();
        }
    }
}
