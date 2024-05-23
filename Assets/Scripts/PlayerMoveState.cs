using UnityEngine;

public class PlayerMoveState : PlayerBaseState
{
    public PlayerMoveState(PlayerStateMachine stateMachine) : base(stateMachine){ }

    public override void Enter()
    {
        stateMachine.Velocity.y = Physics.gravity.y;
    }
    public override void Tick()
    {
        CalculateMoveDirection();
        FaceMoveDirection();
        Move();
        Debug.Log("chceking if tick is calling");
    }
    public override void Exit()
    {
        
    }
}
