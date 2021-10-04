using UnityEngine;
using UnityEngine.EventSystems;

public class DialogPhraseDisplayer : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private Dialog _dialog;

    private int _phrasesAmount;
    private int _currentPhraseIndex;

    private void Start()
    {
        _phrasesAmount = _dialog.GetDialogPhrasesAmount();
        _currentPhraseIndex = _dialog.GetCurrentPhraseIndex();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        _currentPhraseIndex = _dialog.GetCurrentPhraseIndex();

        if (_currentPhraseIndex < _phrasesAmount)
        {
            _dialog.NextPhrase();
        }
        else
        {
            _dialog.EndDialog();
        }
    }
}
