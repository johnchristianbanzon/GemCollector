using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class GameView : MonoBehaviour
{
    [Inject]
    private GameManager _gameManager;
    [Inject]
    private AIThiefAlienBehavior _aiBehavior;
    [SerializeField]
    private GameObject _gameWorldHolder;
    [SerializeField]
    private GameObject _menuWorldHolder;
    [SerializeField]
    private GameObject[] _cameras;
    
    private int _totalTime;

    private void Awake()
    {
        _gameManager.SetView(this);
        _gameManager.Init();
    }
    
   
    public void ShowGame()
    {
        _menuWorldHolder.SetActive(false);
        _gameWorldHolder.SetActive(true);
    }

    public void ShowGameCamera()
    {
        _cameras[0].gameObject.SetActive(false);
        _cameras[1].gameObject.SetActive(true);
    }

    public void ShowMainCamera()
    {
        _cameras[1].gameObject.SetActive(false);
        _cameras[0].gameObject.SetActive(true);
    }

    public void EndGame()
    {
        _aiBehavior.PauseChase();
    }
}