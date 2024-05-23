using System;
using UnityEngine;

[RequireComponent(typeof(InputReader))]
[RequireComponent(typeof(CharacterController))]
public class PlayerStateMachine : StateMachine
{
    public Vector3 Velocity;
    public float MoveSpeed {get; private set;}= 5f;
    public float LookRotationDampFactor {get; private set;} = 10f;
    public Transform MainCamera {get; private set;}
    public InputReader InputReader {get; private set;}
    public CharacterController controller{get; private set;}

    private void Start()
    {
        MainCamera = Camera.main.transform;
        InputReader = GetComponent<InputReader>();
        controller = GetComponent<CharacterController>();

        // we will call switch state so that we can call the first state we need.
        SwitchState(new PlayerMoveState(this));
    }
}
