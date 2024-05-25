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

        Vector3 cameraForward = new(stateMachine.MainCamera.forward.x, 0, stateMachine.MainCamera.forward.z);
        Vector3 cameraRight = new(stateMachine.MainCamera.right.x, 0, stateMachine.MainCamera.right.z);

        Vector3 moveDirection = cameraRight.normalized * stateMachine.InputReader.MoveComposite.x + cameraForward.normalized * stateMachine.InputReader.MoveComposite.y;

        stateMachine.Velocity.x = moveDirection.x * stateMachine.MoveSpeed;
        stateMachine.Velocity.z = moveDirection.z * stateMachine.MoveSpeed;
    }
    protected void FaceMoveDirection()
    {
        Vector3 faceDirection = new(stateMachine.Velocity.x, 0f, stateMachine.Velocity.z);
        if (faceDirection == Vector3.zero)
            return;
        stateMachine.transform.rotation = Quaternion.Slerp(stateMachine.transform.rotation, Quaternion.LookRotation(faceDirection), stateMachine.LookRotationDampFactor * Time.deltaTime);
    }
    protected void ApplyGravity()
    {
        if (stateMachine.Velocity.y > Physics.gravity.y)
        {
            stateMachine.Velocity.y += Physics.gravity.y * Time.deltaTime;
        }
    }
    protected void Move()
    {
        stateMachine.controller.Move(stateMachine.Velocity * Time.deltaTime);
    }
    protected void AimTarget()
    {
        //Vector3 aimPositon = stateMachine.MainCamera.position + stateMachine.MainCamera.forward * stateMachine.aimDistance;
        //Vector3 aimPosition = stateMachine.Camera.ScreenToWorldPoint(new Vector3(Screen.width / 2, Screen.height / 2, stateMachine.aimDistance));
    
        //stateMachine.AimTarget.position = stateMachine.testcam.transform.position + stateMachine.testcam.transform.forward * stateMachine.aimDistance;
        
    }
    protected void Firing()
    {
        RaycastHit hit;
        if (Physics.Raycast(stateMachine.MainCamera.position, stateMachine.MainCamera.forward, out hit, stateMachine.Range))
        {
            Vector3 forceDirection = stateMachine.MainCamera.transform.forward;
            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * stateMachine.ImpactForce);
            }
        }
    }

}
