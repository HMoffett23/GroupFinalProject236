using UnityEngine;
using UnityEngine.InputSystem;

public class KeyboardInput : MonoBehaviour
{
    private bool isDashing;
    private float dashTime = 0.15f;
    private float dashTimer;
    private Vector2 lastMovement = Vector2.right;
    
    public PlayerMovement PlayerMovement;
    
    private void Update()
    {
        if (PlayerMovement == null)
        {
            return;
        }
        Vector2 movement = GetMovement();
        if (movement != Vector2.zero)
        {
            lastMovement = movement;
        }
        
        if (IsSpaceKeyPressed() && !isDashing)
        {
            isDashing = true;
            dashTimer = dashTime;
            PlayerMovement.Dash(lastMovement, this);
        }

        if (!isDashing)
        {
            PlayerMovement.Move(movement);
        }
        else
        {
            dashTimer -= Time.deltaTime;
            if (dashTimer <= 0)
                isDashing = false;
        }
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
    
    private bool IsSpaceKeyPressed()
    {
        return Keyboard.current[GameParameters.Dash].wasPressedThisFrame;
    }
}