using System;
using System.Collections;
using System.Collections.Generic;
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
        _aiBehavior.PauseChase();
    }

    public void StartGame()
    {
        _aiBehavior.ResumeChase();
    }

    public void ShowGameCamera()
    {
        for (int i = 0; i < _cameras.Length; i++)
        {
            _cameras[i].gameObject.SetActive(false);
        }
        _cameras[1].gameObject.SetActive(true);
       
    }

    public void ShowMainCamera()
    {
        for (int i = 0; i < _cameras.Length; i++)
        {
            _cameras[i].gameObject.SetActive(false);
        }
        _cameras[0].gameObject.SetActive(true);
    }

    public void ShowIntroCamera()
    {
        for (int i = 0; i < _cameras.Length; i++)
        {
            _cameras[i].gameObject.SetActive(false);
        }
        _cameras[2].gameObject.SetActive(true);
      
    }
    

    public void EndGame()
    {
        _aiBehavior.PauseChase();
    }
}