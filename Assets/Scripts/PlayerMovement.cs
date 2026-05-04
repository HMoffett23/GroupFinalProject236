using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float Speed = GameParameters.PlayerMovementSpeed;
    public float DashSpeed = GameParameters.PlayerDashSpeed;
    public Rigidbody2D Rigidbody;
    
    private void ApplyMovement(Vector2 direction)
    {
        Rigidbody.linearVelocity = direction * Speed;
    }
    
    public void FaceCorrectDirection(Vector2 direction)
    {
        if (IsNotFacingCorrectDirection(direction))
        {
            FlipFacingDirection();
        }
    }
    
    private void FlipFacingDirection()
    {
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }
    
    private bool IsMoving(Vector2 direction)
    {
        return direction != Vector2.zero;
    }
    
    private bool IsNotFacingCorrectDirection(Vector2 direction)
    {
        return direction.x > 0 && transform.localScale.x < 0 || direction.x < 0 && transform.localScale.x > 0;
    }
    
    public void Move(Vector2 direction, object inputDevice)
    {
        ApplyMovement(direction);
        FaceCorrectDirection(direction);
    }
    
    private void ApplyDashMovement(Vector2 direction)
    {
        Rigidbody.linearVelocity = direction * DashSpeed;
    }
    
    public void Dash(Vector2 direction, object inputDevice)
    {
        ApplyDashMovement(direction);
        FaceCorrectDirection(direction);
    }
}