using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogBoxView : MonoBehaviour
{
    [SerializeField]
    private Text _dialogText;

    private Vector3 _originalPosition;
    private List<string> _dialogList = new List<string>() {
        "Phew! It's so cold here, I should've brought my jacket.",
        "Sheeeeesh",
        "I hear the gems here are better.",
        "Collect gems as much as you can!",
        "Don't get near to that pesky alien thief.",
        "Let me know if you see any gold in here."
    };

    private List<string> _currentList = new List<string>();

    private void Awake()
    {
        
        _originalPosition = transform.position;
    }

    public void Show()
    {
        if (_currentList.Count <= 0)
        {
            _currentList.AddRange(_dialogList);
        }
        var randomDialog = Random.Range(0, _currentList.Count);
        
        _dialogText.text = _currentList[randomDialog];
        _currentList.RemoveAt(randomDialog);
        gameObject.SetActive(true);
        transform.localPosition = Vector3.zero;
        transform.localScale = Vector3.zero;
        transform.DOMove(_originalPosition, 0.4f).SetEase(Ease.OutBack);
        transform.DOScale(Vector3.one, 0.3f).SetEase(Ease.OutBack);
    }

    public void Hide()
    {
        transform.DOLocalMove(Vector3.zero, 0.3f).SetEase(Ease.InBack).OnComplete(
            delegate {
                gameObject.SetActive(false);
            });
        transform.DOScale(Vector3.zero, 0.3f).SetEase(Ease.InBack);
    }
}