using UnityEngine;

public interface IPlayerBehaviour
{
    public void MovePlayer(Vector3 direction);
    public void RotatePlayer(float rotationAngle);
    public Transform GetTransform();
    public void KillPlayer();

    public void AllowMovement(bool allowMovement);
}