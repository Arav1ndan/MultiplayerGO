using System;
using UnityEngine;

[RequireComponent(typeof(InputReader))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(CharacterController))]
public class PlayerStateMachine : StateMachine
{
    public Vector3 Velocity;
    public float MoveSpeed {get; private set;}= 5f;
    public float SprintMultiplier  {get; private set;}
    public float LookRotationDampFactor {get; private set;} = 10f;
    public float JumpForce {get; private set;} = 5f;
    public Transform MainCamera {get; private set;}
    public InputReader InputReader {get; private set;}
    public Animator Animator {get; private set;}
    public CharacterController controller{get; private set;}
    public float Range {get; private set;} = 100f;

    private void Start()
    {
        MainCamera = Camera.main.transform;
        InputReader = GetComponent<InputReader>();
        Animator = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();

        // we will call switch state so that we can call the first state we need.
        SwitchState(new PlayerMoveState(this));
    }
    
}
