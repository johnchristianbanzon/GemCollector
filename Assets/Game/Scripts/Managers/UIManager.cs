using System;
using UnityEngine;
using Zenject;

public class UIManager 
{
    private UIView _uiView;

    public void SetView(UIView uiView)
    {
        _uiView = uiView;
    }

    public void ShowScreen(EnumScreen menuScreen)
    {
        _uiView.ShowScreen(menuScreen);
    }

    public void SetOnClickStartEvent(Action startGame)
    {
        _uiView.SetOnClickStartEvent(startGame);
    }

    public void StartGame()
    {

    }

    public void StartTimer(int timeDuration,Action onEndTimer)
    {
        _uiView.StartTimer(timeDuration, onEndTimer);
    }

    public void ShowPoints(int currentPoints)
    {
        _uiView.ShowPoints(currentPoints);
    }

    public void ShowFloatingPoint(int points, Transform target)
    {
        _uiView.SpawnFloatingPoint(points, target);
    }
}
