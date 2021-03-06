using System;
using UnityEngine.SceneManagement;
using Zenject;

public class GameManager 
{
    [Inject]
    private UIManager _uiManager;
    [Inject]
    private PlayerManager _playerManager;
    [Inject]
    private SoundManager _soundManager;
    [Inject]
    private LoadingManager _loadingManager;
    private GameView _gameView;
    private int _timeDuration = 90;
    private int _currentPoints = 0;
    public void SetView(GameView gameView)
    {
        _gameView = gameView;
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene(0);
    }

    public void Init()
    {
        _uiManager.SetOnClickStartEvent(StartGame);
    }

    public void StartGame()
    {
        _playerManager.AllowMovement(false);

        _loadingManager.ShowLoading(delegate {
            _gameView.ShowIntroCamera();
            _soundManager.PlayGameBGM();
            _uiManager.ShowScreen(EnumScreen.Gameplay);
            _gameView.ShowGame();
            _uiManager.ShowIntroAnimation();
            
        });
    }

    public void ShowGameCamera()
    {
        _gameView.ShowGameCamera();
    }

    public void StartGameTimer()
    {
        _uiManager.StartTimer(_timeDuration, OnEndTimer);
        _gameView.StartGame();
        _playerManager.AllowMovement(true);
    }

    public void ReducePoints()
    {
        var points = -15;
        _currentPoints += points;
        _uiManager.ShowPoints(_currentPoints);
        _uiManager.ShowFloatingPoint(points, _playerManager.GetPlayer().GetTransform());
        _soundManager.PlaySFX("Collect");
        if (_currentPoints <= 0)
        {
            _uiManager.ShowScreen(EnumScreen.Lose);
            _gameView.EndGame();
            _playerManager.KillPlayer();
        }
       
    }

    private void OnEndTimer()
    {
        var scorePass = CalculateScorePass();

        if (scorePass)
        {
            _uiManager.ShowScreen(EnumScreen.Result);
            _gameView.EndGame();
        }
        else
        {
            _uiManager.ShowScreen(EnumScreen.Lose);
        }
    }

    public bool CalculateScorePass()
    {
        if (_currentPoints >= 100)
        {
            return true;
        }
        return false;
    }

    public void AddPoints(EnumGemType gemType)
    {
        var points = ((int)gemType) + 1;
        _currentPoints += points;
        _uiManager.ShowPoints(_currentPoints);
        _uiManager.ShowFloatingPoint(points, _playerManager.GetPlayer().GetTransform());
        _soundManager.PlaySFX("Collect");


    }
}