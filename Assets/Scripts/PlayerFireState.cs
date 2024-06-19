using UnityEngine;

public class PlayerFireState : PlayerBaseState
{
    private readonly int MoveFireHash = Animator.StringToHash("FireSpeed");

    private readonly int FireBlenTreeHash = Animator.StringToHash("FiringTree");
    private const float AnimationDampTime = 0.001f;
    private const float FireSpeedDuration = 0.0001f;

    public PlayerFireState(PlayerStateMachine stateMachine) : base(stateMachine) { }

    private bool isFireButtonPressed = false;
    public override void Enter()
    {
        stateMachine.Animator.CrossFadeInFixedTime(FireBlenTreeHash, FireSpeedDuration);
        //Debug.Log("enterd firestate");
        stateMachine.InputReader.OnJumpPerformed += SwitchToJumpState;
        stateMachine.InputReader.OnFireStarted += OnFireButtonPressed;
        stateMachine.InputReader.OnFireCancelled += OnFireButtonReleased;
    }
    public override void Tick()
    {
        //Debug.Log("Tick fire called");
        CalculateMoveDirection();
        ApplyGravity();
        Firing();
        FaceMoveDirection();
        Move();
        stateMachine.Animator.SetFloat(MoveFireHash, stateMachine.InputReader.MoveComposite.sqrMagnitude > 0f ? 1f : 0f, AnimationDampTime, Time.deltaTime);  
    }
    public override void Exit()
    {
        stateMachine.InputReader.OnJumpPerformed -= SwitchToJumpState;
        stateMachine.InputReader.OnFireStarted -= OnFireButtonPressed;
        stateMachine.InputReader.OnFireCancelled -= OnFireButtonReleased;
    }
    
    private void SwitchToJumpState()
    {
        stateMachine.SwitchState(new PlayerJumpState(stateMachine));
    }
    private void OnFireButtonPressed()
    {
        isFireButtonPressed = true;
    }

    private void OnFireButtonReleased()
    {
        isFireButtonPressed = false;
        SwitchtoMoveState();
    }
    private void SwitchtoMoveState()
    {
        stateMachine.SwitchState(new PlayerMoveState(stateMachine));
    }

}

