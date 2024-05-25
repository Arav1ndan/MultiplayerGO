using UnityEngine;

public class PlayerFireState : PlayerBaseState
{
    public PlayerFireState(PlayerStateMachine stateMachine) : base(stateMachine){ }
    public override void Enter()
    {
        
    }
    public override void Tick()
    {
        ApplyGravity();
        RaycastHit hit;
        if(Physics.Raycast(stateMachine.MainCamera.position, stateMachine.MainCamera.forward,out hit,stateMachine.Range))
        {
            Debug.Log(hit.transform.name + "checking");
        }
        FaceMoveDirection();
        Move();
        stateMachine.SwitchState(new PlayerMoveState(stateMachine));
        
    }
    public override void Exit()
    {
        
    }
}
