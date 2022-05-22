using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

public class InputView : MonoBehaviour
{
    [Inject]
    private InputManager _inputManager;
    [SerializeField]
    private FloatingJoystick _floatingJoystick;
    private bool _allowMovement = false;

    private void MoveRotateWithStick()
    {
        var direction = Vector3.forward * _floatingJoystick.Vertical + Vector3.right * _floatingJoystick.Horizontal;
        _inputManager.MovePlayer(direction);
        var angleA = 0f;
        if (Mathf.Atan2(_floatingJoystick.Horizontal, _floatingJoystick.Vertical) * Mathf.Rad2Deg != 0)
        {
            angleA = Mathf.Atan2(_floatingJoystick.Horizontal, _floatingJoystick.Vertical) * Mathf.Rad2Deg;
        }
        _inputManager.RotatePlayer(angleA);
    }

    private void Awake()
    {
        _inputManager.SetView(this);
    }

    public void StartMoving()
    {
        _allowMovement = true;
    }
    public void StopMoving()
    {
        _allowMovement = false;
    }

    private void FixedUpdate()
    {
        CheckInput();
        if (_allowMovement == false)
        {
            return;
        }
        MoveRotateWithStick();
    }

    private void CheckInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //tap
            StartMoving();
        }

        if (Input.GetMouseButton(0))
        {
            //hold
            StartMoving();
        }

        if (Input.GetMouseButtonUp(0))
        {
            //release
            StopMoving();
        }
    }


}
