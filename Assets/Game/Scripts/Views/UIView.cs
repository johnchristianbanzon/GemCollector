using System;
using UnityEngine;
using Zenject;

public class UIView : MonoBehaviour
{
    [SerializeField]
    private GameObject[] _screensObject;
    [Inject]
    private UIManager _uiManager;
    private IScreen[] _screens;
    private UIGameplayView _uiGameplayView;

    private void Awake()
    {
        _uiManager.SetView(this);
        _screens = new IScreen[_screensObject.Length];
        for (int i = 0; i < _screens.Length; i++)
        {
            _screens[i] = _screensObject[i].GetComponent<IScreen>();
        }
        _uiGameplayView = _screensObject[(int)EnumScreen.Gameplay].GetComponent<UIGameplayView>();
    }

    public void SetOnClickStartEvent(Action onStartGame)
    {
        _screensObject[(int)EnumScreen.MainMenu].GetComponent<UIMainMenuView>().SetOnStartEvent(onStartGame);
    }

    public void ShowPoints(int currentPoints)
    {
        _uiGameplayView.ShowPoints(currentPoints);
    }

    public void ShowIntroAnimation()
    {
        _uiGameplayView.ShowIntro();
    }

    public void SpawnFloatingPoint(int points,Transform target)
    {
        _uiGameplayView.ShowFloatingPoint(points, target);
    }

    public void ShowScreen(EnumScreen menuScreen)
    {
        for (int i = 0; i < _screens.Length; i++)
        {
            _screens[i].Hide();
        }
        _screens[(int)menuScreen].Show();
    }

    public void StartTimer(int totalTime, Action onEndTimer)
    {
        _uiGameplayView.StartTimer(totalTime, onEndTimer);
    }

}