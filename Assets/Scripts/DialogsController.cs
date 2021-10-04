using UnityEngine;
using UnityEngine.UI;

public class DialogsController : MonoBehaviour
{
    [SerializeField] private Sprite[] _phrasesImages;
    private Image _phraseDisplay;

    public static DialogsController Instance = null;

    /*
    public delegate void DialogStarted();
    public event DialogStarted OnDialogStarted = delegate { };

    public delegate void DialogFinished();
    public event DialogFinished OnDialogFinished = delegate { };

    */

    public void DisplayPhrase(string phraseImageName, Vector3 displayPosition, Image phraseDisplayer)
    {
        _phraseDisplay = phraseDisplayer;
        _phraseDisplay.gameObject.transform.parent.gameObject.SetActive(true);
        _phraseDisplay.gameObject.transform.parent.position = displayPosition;

        foreach (var image in _phrasesImages)
        {
            if (image.name == phraseImageName)
            {
                _phraseDisplay.sprite = image;
                //OnDialogStarted();
                return;
            }
        }

        _phraseDisplay.gameObject.SetActive(false);
    }

    public void StopDisplayingPhrases()
    {
        _phraseDisplay.gameObject.transform.parent.gameObject.SetActive(false);
       // OnDialogFinished();
    }

    private void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

    }
}
