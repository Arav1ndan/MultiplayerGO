using UnityEngine;
using UnityEngine.InputSystem;

public class InputReader : MonoBehaviour , Controls.IPlayerActions
{
    public Vector2 MoveComposite;
    public void OnMove(InputAction.CallbackContext context)
    {
        MoveComposite = context.ReadValue<Vector2>();
    }
}
