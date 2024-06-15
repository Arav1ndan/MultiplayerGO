using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

[RequireComponent(typeof(CharacterController),typeof(PlayerInput))]

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float PlayerWalk = 3.0f;
    [SerializeField] private float PlayerRun =  6.0f;
    [SerializeField] private float JumpForce = 10.0f;
    [Space]
    private float RotationSpeed = 2f;
    private bool PlayerGround;
    private float gravity = -9.81f;
    private NewInput newinput;
    private CharacterController controller;

    [Space]
    //private PlayerInput PlayerInput;
    
    private InputAction MoveAction;
    //private InputAction JumpAction;
    //private InputAction ShootAction;
    private Vector2 moveVector;

    void Awake()
    {
        controller = GetComponent<CharacterController>();
        //PlayerInput = GetComponent<PlayerInput>();
        MoveAction = newinput.Player.Move;
        //JumpAction = PlayerInput.actions["Jump"];
        //ShootAction = PlayerInput.actions["Fire"];
        newinput = new NewInput();
        newinput.Player.Enable();
    }
    private void OnEnable()
    {
        //InputAction shootAction = GetComponent<PlayerInput>().actions["Player/Shoot"];
        //ShootAction.performed += _ => ShootGun();
    }
    private void OnDisable()
    {
        //InputAction shootAction = GetComponent<PlayerInput>().actions["Player/Shoot"];
       // ShootAction.performed += _ => ShootGun();
       newinput.Player.Disable();
    }
    private void ShootGun()
    {

    }
    void Update()
    {
        //Vector2 input = MoveAction.ReadValue<Vector2>();
        Move();
    }
    private void OnMove(InputAction.CallbackContext context){
        moveVector = context.ReadValue<Vector2>();
    }
    private void Move()
    {
        Vector3 move = transform.right * moveVector.x + transform.forward * moveVector.y;
        controller.Move(move * PlayerWalk * Time.deltaTime);
    }
    
}
