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
        Debug.Log(moveDirection + "value");
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
    /*protected void AimTarget()
    {
        stateMachine.AimTarget.position = stateMachine.cinemachineVirtualCamera.transform.position + stateMachine.cinemachineVirtualCamera.transform.forward * stateMachine.aimDistance;
        
    }*/
    protected void Firing()
    {
        
        //stateMachine.InputReader.OnFirePerformed?.Invoke();
        stateMachine.flash.Play();
        Ray ray = stateMachine.Camera.ViewportPointToRay(new Vector3(0.5f,0.5f));
        ray.origin = stateMachine.Camera.transform.position;
        //RaycastHit hit;
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            Debug.Log(hit.collider.name);
            Vector3 forceDirection = stateMachine.MainCamera.transform.forward;
            if (hit.rigidbody != null)
            {
                hit.rigidbody.AddForce(-hit.normal * stateMachine.ImpactForce);
            }
        }
    }

}
