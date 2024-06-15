using System;
using UnityEngine;
using UnityEngine.InputSystem;
using Photon.Pun;

public class InputReader : MonoBehaviourPunCallbacks, Controls.IPlayerActions
{
    public Vector2 MoveComposite;
    public Vector2 MouseDelta;
    public Action OnJumpPerformed;
    public event Action OnFireStarted;
    public event Action OnFireCancelled;
    private Controls controls;
    private void Awake()
    {
        if (controls != null)
            return;
        if (photonView.IsMine)
        {
            controls = new Controls();
            controls.Player.SetCallbacks(this);
            controls.Player.Enable();
        }
    }
    public override void OnDisable()
    {
        if (photonView.IsMine)
            controls.Player.Disable();
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        if (photonView.IsMine)
            MoveComposite = context.ReadValue<Vector2>();
    }
    public void OnLook(InputAction.CallbackContext context)
    {
        if (photonView.IsMine)
        {
            MouseDelta = context.ReadValue<Vector2>();
        }

    }
    public void OnJump(InputAction.CallbackContext context)
    {
        if (photonView.IsMine)
        {
            if (!context.performed)
                return;
            OnJumpPerformed?.Invoke();
        }
    }
    public void OnSprint(InputAction.CallbackContext context)
    {
        if (!context.performed)
            return;

    }
    public void OnFire(InputAction.CallbackContext context)
    {
        if (photonView.IsMine)
        {
            if (context.started)
            {
                Debug.Log("Fire started");
                OnFireStarted?.Invoke();
            }
            else if (context.canceled)
            {
                Debug.Log("Fire cancelled");
                OnFireCancelled?.Invoke();
            }
        }
    }
}
    


