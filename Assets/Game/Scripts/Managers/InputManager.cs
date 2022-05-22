using UnityEngine;
using Zenject;

public class InputManager
{
    private InputView _inputView;
    [Inject]
    private PlayerManager _playerManager;

    public void SetView(InputView inputView)
    {
        _inputView = inputView;
    }

    public void MovePlayer(Vector3 direction)
    {
        _playerManager.MovePlayer(direction);
    }

    public void RotatePlayer(float angleA)
    {
        _playerManager.RotatePlayer(angleA);
    }
}