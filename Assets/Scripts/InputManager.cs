using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager
{
    private InputControls inputControls;
    private Vector2 InputDirection => inputControls.Player.Move.ReadValue<Vector2>();

    public event Action OnPlayerAttack;
 
    public InputManager()
    {
        Debug.Log("InputManager Started!");
        inputControls = new InputControls();
        inputControls.Enable();

        inputControls.Player.Attack.performed += OnPlayerAttackPerformed;
    }
    
    private void OnPlayerAttackPerformed(InputAction.CallbackContext obj)
    {
        OnPlayerAttack.Invoke();
    }

    public Vector2 GetInputDirection() => InputDirection;
    
    private void OnDestroy()
    {
        inputControls.Disable();
    }

    private void OnDisable()
    {
        inputControls.Disable();
    }
}
