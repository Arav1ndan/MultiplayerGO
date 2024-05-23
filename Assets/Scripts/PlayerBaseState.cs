using UnityEngine;

public abstract class PlayerBaseState : State
{
    protected readonly PlayerStateMachine stateMachine;

    protected PlayerBaseState(PlayerStateMachine stateMachine)
    {
        this.stateMachine = stateMachine;
    }
    protected void CalculateMoveDirection()
    {
        Debug.Log("Calculating Move Direction");
        Vector3 cameraForward = new(stateMachine.MainCamera.forward.x,0,stateMachine.MainCamera.forward.z);
        Vector3 cameraRight = new(stateMachine.MainCamera.right.x,0,stateMachine.MainCamera.right.z);

        Vector3 moveDirection =   cameraRight.normalized * stateMachine.InputReader.MoveComposite.y + cameraForward.normalized * stateMachine.InputReader.MoveComposite.x;
        Debug.Log("Move Composite X: " + stateMachine.InputReader.MoveComposite.x + ", Y: " + stateMachine.InputReader.MoveComposite.y);
        Debug.Log("Calculated Move Direction: " + moveDirection);

        stateMachine.Velocity.x = moveDirection.x * stateMachine.MoveSpeed;
        stateMachine.Velocity.z = moveDirection.z * stateMachine.MoveSpeed;
    }
    protected void FaceMoveDirection()
    {
        Vector3 faceDirection = new(stateMachine.Velocity.x,0f,stateMachine.Velocity.z);
        if(faceDirection == Vector3.zero)
            return;
        stateMachine.transform.rotation = Quaternion.Slerp(stateMachine.transform.rotation,Quaternion.LookRotation(faceDirection),stateMachine.LookRotationDampFactor * Time.deltaTime);
    }
    protected void ApplyGravity()
    {
        if(stateMachine.Velocity.y > Physics.gravity.y){
            stateMachine.Velocity.y += Physics.gravity.y * Time.deltaTime;
        }
    }
    protected void Move()
    {
        stateMachine.controller.Move(stateMachine.Velocity * Time.deltaTime);
    }
    
}
