using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Dialog : MonoBehaviour
{
    [SerializeField] private string[] _phrasesImageNames;
    [SerializeField] private Vector3 _dialogCloudPosition;

    public delegate void DialogEnded();
    public event DialogEnded OnDialogEnded = delegate { };

    private int _currentPhraseIndex;

    private void Start()
    {
        _currentPhraseIndex = 0;
    }

    public void StartDialog()
    {
        DialogsController.Instance.DisplayPhrase(_phrasesImageNames[_currentPhraseIndex], _dialogCloudPosition);
        _currentPhraseIndex++;
    }

    public void NextPhrase()
    {
        DialogsController.Instance.DisplayPhrase(_phrasesImageNames[_currentPhraseIndex], _dialogCloudPosition);
        _currentPhraseIndex++;
    }

    public void EndDialog()
    {
        DialogsController.Instance.StopDisplayingPhrases();
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
