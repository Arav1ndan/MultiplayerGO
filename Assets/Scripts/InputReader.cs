using System;
using UnityEngine;
using UnityEngine.InputSystem;
using Photon.Pun;

public class InputReader : MonoBehaviourPunCallbacks, Controls.IPlayerActions
{
    public Vector2 MoveComposite;
    public Vector2 MouseDelta;
    public Action OnJumpPerformed;
    public bool OnFirePerformed;
    private Controls controls;
    private WeaponScript weaponScript;
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
        if(photonView.IsMine)
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
        OnFirePerformed = context.performed;
    }

}
