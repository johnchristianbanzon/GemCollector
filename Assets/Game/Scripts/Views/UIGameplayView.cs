using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIGameplayView : MonoBehaviour, IScreen
{
    [SerializeField]
    private Text _timerText;
    [SerializeField]
    private Text _pointsText;
    private Action _onEndTimer;
    private int _totalTime;
    private int _currentTime;
    private List<FloatingPointsView> _floatingTextPool = new List<FloatingPointsView>();

    public void StartTimer(int totalTime, Action onEndTimer)
    {
        _onEndTimer = onEndTimer;
        _totalTime = totalTime;
        StartCoroutine("StartTimerCountdown");
    }

    private IEnumerator StartTimerCountdown()
    {
        _currentTime = _totalTime;
        for (int i = 0; i < _totalTime; i++)
        {
            _currentTime--;
            yield return new WaitForSeconds(1);
            _timerText.text = GetTimeStringFromSeconds(_currentTime);
        }
        _onEndTimer?.Invoke();
    }

    public string GetTimeStringFromSeconds(float totalTime)
    {
        var minutes = totalTime % 3600 / 60f;
        var seconds = totalTime % 60f;
        var minutesText = Mathf.FloorToInt(minutes);
        var secondsText = seconds;

        return minutesText + ":" + secondsText.ToString("00");
    }

    public void ShowFloatingPoint(int points, Transform target)
    {
        for (int i = 0; i < _floatingTextPool.Count; i++)
        {
            if (_floatingTextPool[i].GetIsShowing() == false)
            {
                _floatingTextPool[i].Show(points);
                return;
            }
           
        }
        var newFloatingPoint = (Instantiate(Resources.Load("Prefabs/FloatingText"), transform) as GameObject).GetComponent<FloatingPointsView>();
        newFloatingPoint.SetTarget(target);
        newFloatingPoint.Show(points);
        _floatingTextPool.Add(newFloatingPoint);
    }

    public void ShowPoints(int currentPoints)
    {
        _pointsText.text = currentPoints.ToString();
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }
}
