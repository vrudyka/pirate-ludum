using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Dialog : MonoBehaviour
{
    [SerializeField] private string[] _phrasesImageNames;
    [SerializeField] private Vector3 _dialogCloudPosition;
    [SerializeField] private Image _phraseDisplay;

    public delegate void DialogStarted();
    public static event DialogStarted OnDialogStarted = delegate { };

    public delegate void DialogEnded();
    public static event DialogEnded OnDialogEnded = delegate { };

    private int _currentPhraseIndex;

    private void Start()
    {
        _currentPhraseIndex = 0;
    }

    public void StartDialog()
    {
        DialogsController.Instance.DisplayPhrase(_phrasesImageNames[_currentPhraseIndex], _dialogCloudPosition, _phraseDisplay);
        _currentPhraseIndex++;
        OnDialogStarted();
    }

    public void NextPhrase()
    {
        DialogsController.Instance.DisplayPhrase(_phrasesImageNames[_currentPhraseIndex], _dialogCloudPosition, _phraseDisplay);
        _currentPhraseIndex++;
    }

    public void EndDialog()
    {
        DialogsController.Instance.StopDisplayingPhrases();
        OnDialogEnded();
    }

    public int GetDialogPhrasesAmount()
    {
        return _phrasesImageNames.Length;
    }

    public int GetCurrentPhraseIndex()
    {
        return _currentPhraseIndex;
    }
}
