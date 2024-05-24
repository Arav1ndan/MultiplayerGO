using UnityEngine;

public class PlayerJumpState : PlayerBaseState
{
   private readonly int JumpHash = Animator.StringToHash("Jump");
   private const float JumpSpeed = 0.1f;
   public PlayerJumpState(PlayerStateMachine stateMachine) : base(stateMachine) { }

   public override void Enter()
   {
      stateMachine.Velocity = new Vector3(stateMachine.Velocity.x, stateMachine.JumpForce, stateMachine.Velocity.z);

      stateMachine.Animator.CrossFadeInFixedTime(JumpHash, JumpSpeed);
   }
   public override void Tick()
   {
      ApplyGravity();
      if (stateMachine.Velocity.y <= 0f)
      {
         stateMachine.SwitchState(new PlayerFallState(stateMachine));
      }
      FaceMoveDirection();
      Move();
   }
   public override void Exit()
   {

   }
}
