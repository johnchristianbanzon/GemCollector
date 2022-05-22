using DG.Tweening;
using System;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class BlackLoadingView : MonoBehaviour
{
    [SerializeField]
    private Image _loading;
    [Inject]
    private LoadingManager _loadingManager;

    private void Awake()
    {
        _loadingManager.SetView(this);
        _loading.gameObject.SetActive(false);
    }

    public void ShowLoading(Action onMidwayLoad)
    {
        _loading.gameObject.SetActive(true);
        _loading.DOFade(0, 0.001f);
        _loading.DOFade(1, 1.0f).OnComplete(delegate
        {
            onMidwayLoad?.Invoke();
            _loading.DOFade(0, 1.2f).SetDelay(0.5f).OnComplete(delegate{
                _loading.gameObject.SetActive(false);
            });
        });

    }
}
