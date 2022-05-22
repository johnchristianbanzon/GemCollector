using System;
using UnityEngine;
using Zenject;

public class PlayerManager 
{
    public IPlayerBehaviour _playerBehaviour;
    [Inject]
    private GameManager _gameManager;

    public void MovePlayer(Vector3 direction)
    {
        _playerBehaviour.MovePlayer(direction);
    }


    public void RotatePlayer(float rotationAngle)
    {
        _playerBehaviour.RotatePlayer(rotationAngle);
    }

    public IPlayerBehaviour GetPlayer()
    {
        return _playerBehaviour;
    }

    public void SetBehaviour(PlayerBehaviour playerBehaviour)
    {
        _playerBehaviour = playerBehaviour;
    }

    public void AddPoints(EnumGemType gemType)
    {
        _gameManager.AddPoints(gemType);
    }

    public void ReducePoints()
    {
        _gameManager.ReducePoints();
    }

    public void KillPlayer()
    {
        _playerBehaviour.KillPlayer();
    }
}