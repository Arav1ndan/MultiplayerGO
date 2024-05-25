using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputReader : MonoBehaviour, Controls.IPlayerActions
{
    public Vector2 MoveComposite;
    public Vector2 MouseDelta;
    public Action OnJumpPerformed;  
    public Action onFirePerformed;
    private Controls controls;
    private void Awake()
    {
        if (controls != null)
            return;

        controls = new Controls();
        controls.Player.SetCallbacks(this);
        controls.Player.Enable();
    }
    public void OnDisable()
    {
        controls.Player.Disable();
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        MoveComposite = context.ReadValue<Vector2>();
    }
    public void OnLook(InputAction.CallbackContext context)
    {
        MouseDelta = context.ReadValue<Vector2>();
    }
    public void OnJump(InputAction.CallbackContext context)
    {
        if (!context.performed)
            return;
        OnJumpPerformed?.Invoke();
    }
    public void OnSprint(InputAction.CallbackContext context)
    {
        if(!context.performed)
            return;
        
    }
    public void OnFire(InputAction.CallbackContext context)
    {
        if(!context.performed)
            return;
        onFirePerformed?.Invoke();
    }
}
