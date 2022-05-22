using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class UIGameplayView : MonoBehaviour, IScreen
{
    [SerializeField]
    private Text _timerText;
    [SerializeField]
    private Text _pointsText;
    [SerializeField]
    private Text _readyText;
    [SerializeField]
    private Text _goText;
    private Action _onEndTimer;
    private int _totalTime;
    private int _currentTime;
    private List<FloatingPointsView> _floatingTextPool = new List<FloatingPointsView>();
    [Inject]
    private GameManager _gameManager;

    public void StartTimer(int totalTime, Action onEndTimer)
    {
        _onEndTimer = onEndTimer;
        _totalTime = totalTime;
        StartCoroutine("StartTimerCountdown");
    }

    public void ShowIntro()
    {
        StartCoroutine("ShowIntroAnimation");
    }

    private IEnumerator ShowIntroAnimation()
    {
        var normalPosition = _readyText.transform.position;
        _readyText.gameObject.SetActive(true);
        _readyText.transform.localScale = Vector3.zero;
        _readyText.transform.position -= new Vector3(200, 0, 0);
        _readyText.DOFade(0, 0.005f);
        _readyText.DOFade(1, 0.1f);
        _readyText.transform.DOMove(normalPosition, 0.2f).SetEase(Ease.Linear);
        _readyText.transform.DOScale(Vector3.one, 0.2f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(1.4f);
        normalPosition += new Vector3(200, 0, 0);
        _readyText.DOFade(0, 0.1f);
        _readyText.transform.DOMove(normalPosition, 0.2f).SetEase(Ease.Linear);
        _readyText.transform.DOScale(Vector3.zero, 0.2f).SetEase(Ease.Linear);
        
        yield return new WaitForSeconds(1.4f);
        _gameManager.ShowGameCamera();
        yield return new WaitForSeconds(2f);
        _gameManager.StartGameTimer();
        normalPosition = _goText.transform.position;
        _goText.gameObject.SetActive(true);
        _goText.transform.localScale = Vector3.zero;
        _goText.transform.position -= new Vector3(200, 0, 0);
        _goText.DOFade(0, 0.005f);
        _goText.DOFade(1, 0.1f);
        _goText.transform.DOMove(normalPosition, 0.2f).SetEase(Ease.Linear);
        _goText.transform.DOScale(Vector3.one, 0.2f).SetEase(Ease.Linear);
        yield return new WaitForSeconds(1.4f);
        normalPosition += new Vector3(200, 0, 0);
        _goText.DOFade(0, 0.1f);
        _goText.transform.DOMove(normalPosition, 0.2f).SetEase(Ease.Linear);
        _goText.transform.DOScale(Vector3.zero, 0.2f).SetEase(Ease.Linear);
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
