using UnityEngine;

public class PlayerMoveState : PlayerBaseState 
{
    private readonly int MoveSpeedHash = Animator.StringToHash("MoveSpeed");
    
    private readonly int MoveBlendTreeHash = Animator.StringToHash("MoveTree");
    private const float AnimationDampTime = 0.1f;
    private const float MoveSpeedDuration = 0.1f;
    public PlayerMoveState(PlayerStateMachine stateMachine) : base(stateMachine){ }

    public override void Enter()
    {
        stateMachine.Velocity.y = Physics.gravity.y;
        stateMachine.Animator.CrossFadeInFixedTime(MoveBlendTreeHash,MoveSpeedDuration);
        //Debug.Log("CrossFadeInFixedTime called with BlendTreeHash: " + MoveBlendTreeHash);
        stateMachine.InputReader.OnJumpPerformed += SwitchToJumpState;
        stateMachine.InputReader.OnFireStarted += SwitchToFireState;
    }
    public override void Tick()
    {
        if(!stateMachine.controller.isGrounded)
        {
            stateMachine.SwitchState(new PlayerFallState(stateMachine));
        }
        CalculateMoveDirection();
        ApplyGravity();
        FaceMoveDirection();
        Move();
        //Firing();
        //AimTarget();
        stateMachine.Animator.SetFloat(MoveSpeedHash,stateMachine.InputReader.MoveComposite.sqrMagnitude > 0f? 1f : 0f,AnimationDampTime, Time.deltaTime);

    }
    public override void Exit()
    {
       stateMachine.InputReader.OnJumpPerformed -= SwitchToJumpState;
       stateMachine.InputReader.OnFireCancelled-= SwitchToFireState;
    }
    private void SwitchToJumpState()
    {
        stateMachine.SwitchState(new PlayerJumpState(stateMachine));
    }
    private void SwitchToFireState()
    {
        stateMachine.SwitchState(new PlayerFireState(stateMachine));
    }
}
