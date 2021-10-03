using UnityEngine;
using UnityEngine.UI;

public class DialogsHandler : MonoBehaviour
{
    [SerializeField] private Sprite[] _phrasesImages;
    [SerializeField] private Image _phraseDisplay;

    public static DialogsHandler Instance = null;

    public void DisplayPhrase(string phraseImageName, Vector3 displayPosition)
    {
        _phraseDisplay.gameObject.SetActive(true);
        _phraseDisplay.gameObject.transform.position = displayPosition;

        foreach (var image in _phrasesImages)
        {
            if (image.name == phraseImageName)
            {
                _phraseDisplay.sprite = image;
                return;
            }
        }
    }

    public void StopDisplayingAnPhrase()
    {
        _phraseDisplay.gameObject.SetActive(false);
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

        DontDestroyOnLoad(gameObject);
    }
}
