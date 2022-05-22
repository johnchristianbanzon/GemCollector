using System;
using UnityEngine;
using Zenject;

public class PlayerBehaviour : MonoBehaviour, IPlayerBehaviour
{
    [Inject]
    private PlayerManager _playerManager;
    [SerializeField]
    private AnimationBehavior _animationBehavior;
    [SerializeField]
    private Rigidbody _playerRigidBody;
    [SerializeField]
    private float _speed;
    [SerializeField]
    private float _rotateSpeed;
    private bool _isAnimating = false;
    private bool _isDead;
    private bool _allowMovement;

    private void Awake()
    {
        _playerManager.SetBehaviour(this);
    }

    private void FixedUpdate()
    {
        if (_isDead)
        {
            return;
        }
        if(_playerRigidBody.velocity != Vector3.zero)
        {
            if (_animationBehavior.GetCurrentAnimationString()!= "Run")
            {
                _animationBehavior.Play("Run");
            }
        }
        else
        {
            if (_animationBehavior.GetCurrentAnimationString() != "Idle")
            {
                _animationBehavior.Play("Idle");
            }
        }
    }

    public void AllowMovement(bool allowMovement)
    {
        _allowMovement = allowMovement;
    }

    public void Retrieve(EnumGemType gemType)
    {
        _playerManager.AddPoints(gemType);
    }

    public void MovePlayer(Vector3 direction)
    {
        if (_allowMovement==false)
        {
            return;
        }
        _playerRigidBody.AddForce(direction * _speed * Time.fixedDeltaTime, ForceMode.VelocityChange);
        //_playerRigidBody.velocity = 9 * (_playerRigidBody.velocity.normalized);
        if (_playerRigidBody.velocity.magnitude > 6)
        {
            _playerRigidBody.velocity = _playerRigidBody.velocity.normalized * 6;
        }
    }

    public void RotatePlayer(float rotationAngle)
    {
        if (_allowMovement==false)
        {
            return;
        }
        transform.eulerAngles = new Vector3(0f, rotationAngle, 0f);
    }

    public void HitPlayer()
    {
        _playerManager.ReducePoints();
    }

    public Transform GetTransform()
    {
        return transform;
    }

    public void KillPlayer()
    {
        _isDead = true;
        _animationBehavior.Play("Death");
    }
}
