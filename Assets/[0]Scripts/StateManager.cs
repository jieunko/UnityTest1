using UnityEngine;
using System.Collections;



public class StateManager {
/*
    private JumpState jump;
    private IdleState idle;
    private RunState run;
    */
    private IState preState;

    private IPlayerControl player;

 //   private bool bJumping = false;

    public StateManager(IPlayerControl _player) {
        player = _player;
        preState = new IdleState(player);
    }  
    void SetState(IState state)
    {
        preState.OnEnd();
        preState = state;
        preState.OnStart();
    }

    public void SetIdleState()
    {
        //  if (preState is IdleState || bJumping == true)

        if (preState is IdleState)
            return;
        // SetState(idle);
        SetState(new IdleState(player));
    }
    public void SetRunState()
    {
        //if (preState is RunState || bJumping == true)
        if (preState is RunState)
            return;
        SetState(new RunState(player));
    }
    public void SetJumpState()
    {

        Debug.Log("jump State occurred");
        if (preState is JumpState)
            
            return;
        SetState(new JumpState(player));
    }

    public void Tick() {
        preState.OnUpdate();
    }

}
