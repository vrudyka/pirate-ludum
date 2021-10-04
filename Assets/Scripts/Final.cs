using UnityEngine;

public class Final : MonoBehaviour
{
    [SerializeField] private GameObject _gameObject;

    private void Start()
    {
        Dialog.OnDialogEnded += EnableFinalPanel;
    }

    private void EnableFinalPanel()
    {
        _gameObject.SetActive(true);
    }

    private void OnDisable()
    {
        Dialog.OnDialogEnded -= EnableFinalPanel;
    }
}
