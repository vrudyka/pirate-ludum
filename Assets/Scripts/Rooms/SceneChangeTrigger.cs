using UnityEngine;

public class SceneChangeTrigger : MonoBehaviour
{
    [SerializeField] private string _sceneToLoadName;

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
                SceneController.Instance.LoadScene(_sceneToLoadName);
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
