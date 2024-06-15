using UnityEngine;

public class PlayerFallState : PlayerBaseState
{
    private readonly int FallHash = Animator.StringToHash("Fall");
    private const float FallSpeed = 0.2f;
    public PlayerFallState(PlayerStateMachine stateMachine): base(stateMachine){ }
    public override void Enter()
    {
        stateMachine.Velocity.y = 0f;
        stateMachine.Animator.CrossFadeInFixedTime(FallHash, FallSpeed);
    }
    public override void Tick()
    {
        ApplyGravity();
        //Firing();
        Move();
        if(stateMachine.controller.isGrounded)
        {
            stateMachine.SwitchState(new PlayerMoveState(stateMachine));
        }
    }
    public override void Exit(){}
}
