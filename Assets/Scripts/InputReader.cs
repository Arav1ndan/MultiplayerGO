using UnityEngine;
using UnityEngine.InputSystem;

public class InputReader : MonoBehaviour , Controls.IPlayerActions
{
    public Vector2 MoveComposite;
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
        controls.Disable();
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        MoveComposite = context.ReadValue<Vector2>();
        //Debug.Log("let see if the input is coming?" + MoveComposite);
    }
    public void OnLook(InputAction.CallbackContext context)
    {

    }
}
