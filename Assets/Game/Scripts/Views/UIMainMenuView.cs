using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UIMainMenuView : MonoBehaviour, IScreen
{
    [SerializeField]
    private Button _startGameButton;
    [SerializeField]
    private DialogBoxView _dialogBoxView;
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
        StartCoroutine("StartDialogInterval");
    }

    private IEnumerator StartDialogInterval()
    {
        yield return new WaitForSeconds(3f);
        _dialogBoxView.Show();
        yield return new WaitForSeconds(6f);
        _dialogBoxView.Hide();
        StartCoroutine("StartDialogInterval");

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