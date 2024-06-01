using UnityEngine;

public class PlayerFireState : PlayerBaseState
{
    //private readonly int FireHash = Animator.StringToHash("tryidel");
    //private const float FireSpeed = 1f;
    public PlayerFireState(PlayerStateMachine stateMachine) : base(stateMachine){ }
    public override void Enter()
    {
        //stateMachine.Animator.CrossFade(FireHash,FireSpeed);
        
       
    }
    public override void Tick()
    {
        Debug.Log("Tick fire called");
        if (stateMachine.InputReader.OnFirePerformed)
        {
            
        }
        ApplyGravity();
        AimTarget();
        Firing();
        FaceMoveDirection();
        Move();     
        stateMachine.SwitchState(new PlayerMoveState(stateMachine));        
    }
    public override void Exit()
    {
        
    }
   
}

