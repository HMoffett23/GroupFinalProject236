using UnityEngine;
using UnityEngine.InputSystem;

public class KeyboardInput : MonoBehaviour
{
    public PlayerMovement PlayerMovement;
    private void Update()
    {
        if (PlayerMovement == null)
        {
            return;
        }
        Vector2 movement = GetMovement();
        PlayerMovement.Move(movement, this);
    }
    public Vector2 GetMovement()
    {
        float horizontalInput = GetHorizontalInput();
        float verticalInput = GetVerticalInput();
        Vector2 movement = new Vector2(horizontalInput, verticalInput);
        movement = AdjustForDiagonalMovement(movement);
        return movement;
    }
   
    private float GetHorizontalInput()
    {
        float horizontal = 0f;
        if (IsLeftKeyPressed())
        {
            horizontal = horizontal - 1f;
        }
        if (IsRightKeyPressed())
        {
            horizontal = horizontal + 1f;
        }
        return horizontal;
    }
    private float GetVerticalInput()
    {
        float vertical = 0f;
        if (IsUpKeyPressed())
        {
            vertical = vertical + 1f;
        }
        if (IsDownKeyPressed())
        {
            vertical = vertical - 1f;
        }
        return vertical;
    }
    
    private bool IsLeftKeyPressed()
    {
        return Keyboard.current[GameParameters.MoveLeft].isPressed;
    }

    private bool IsRightKeyPressed()
    {
        return Keyboard.current[GameParameters.MoveRight].isPressed;
    }

    private bool IsUpKeyPressed()
    {
        return Keyboard.current[GameParameters.MoveUp].isPressed;
    }

    private bool IsDownKeyPressed()
    {
        return Keyboard.current[GameParameters.MoveDown].isPressed;
    }
    
    private Vector2 AdjustForDiagonalMovement(Vector2 movement)
    {
        if (IsDiagonalMovement(movement))
        {
            movement.Normalize();
        }
        return movement;
    }
    
    private bool IsDiagonalMovement(Vector2 movement)
    {
        return movement.sqrMagnitude > 1f;
    }
}