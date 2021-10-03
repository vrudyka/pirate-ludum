using UnityEngine;

public class BatyaMouth : MonoBehaviour
{
    [SerializeField] private GameObject _openMouth;
    [SerializeField] private GameObject _closedMouth;

    public delegate void MouthOpened();
    public static event MouthOpened OnMouthOpened = delegate { };

    public delegate void MouthClosed();
    public static event MouthOpened OnMouthClosed = delegate { };

    private void Start()
    {
        OpenMouth();
    }

    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.CompareTag("Player"))
        {
            CloseMouth();
            OnMouthClosed();
        }
    }

    private void OnTriggerExit2D(Collider2D collider2D)
    {
        if (collider2D.CompareTag("Player"))
        {
            OpenMouth();
            OnMouthOpened();
        }
    }

    private void OpenMouth()
    {
        _openMouth.SetActive(true);
        _closedMouth.SetActive(false);
    }

    private void CloseMouth()
    {
        _openMouth.SetActive(false);
        _closedMouth.SetActive(true);
    }
}
