using UnityEngine;
using Photon.Pun;

public class StateMachine : MonoBehaviourPunCallbacks
{
    
    //we are making current state because we know at a time we can only use one state
    private State CurrentState;
    //Now we are making a switch state so that we can switch states we -
    //are give parameter as state to check which state is the right now.
    public void SwitchState(State state)
    {
        //here we cheack which state are we in?
        //first we check did we leave that current state. ig.
        CurrentState?.Exit();
        //we will add the state we are in to current state
        CurrentState = state;
        // we will check did we enter that state here.
        CurrentState.Enter();
    }
    //we will update the state in update method.
    public void Update()
    {
        //This logic runs every frame (sometimes called Execute or Tick) . 
        //You can further segment the Update method as MonoBehaviour does, 
        //using a FixedUpdate for physics, LateUpdate, and so on .
        CurrentState?.Tick();
    }

}
