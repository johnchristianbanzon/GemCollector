using System;
using UnityEngine;
using UnityEngine.UI;

public class UIMainMenuView : MonoBehaviour, IScreen
{
    [SerializeField]
    private Button _startGameButton;
    private Action _onClickStart;

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }


    private void Awake()
    {
        _startGameButton.onClick.AddListener(OnClickStart);
    }

    public void SetOnStartEvent(Action onClickStart)
    {
        _onClickStart = onClickStart;
    }

    private void OnClickStart()
    {
        _onClickStart?.Invoke();
    }
}