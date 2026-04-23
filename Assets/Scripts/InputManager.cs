using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager
{
    private InputControls inputControls;
    private Vector2 InputDirection => inputControls.Player.Move.ReadValue<Vector2>();
    #region Referência de implementação - Não será utilizado no projeto
    public event Action OnAttackPressed;
    #endregion

    public InputManager()
    {
        Debug.Log("InputManager Started!");
        inputControls = new InputControls();
        inputControls.Enable();

        inputControls.Player.Attack.performed += OnAttackPerformed;
    } 
    
    #region Referência de implementação - Não será utilizado no projeto
    private void OnAttackPerformed(InputAction.CallbackContext obj)
    {
        OnAttackPressed?.Invoke();
        //? depois do evento = Alguém se inscreveu no evento? Se sim, Invoca ele!
    }
#endregion
    public Vector2 GetInputDirection() => InputDirection;
    // {
    //     return InputDirection;
    // }
    
    private void OnDestroy()
    {
        inputControls.Disable();
    }

    private void OnDisable()
    {
        inputControls.Disable();
    }
}
