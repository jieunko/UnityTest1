using UnityEngine;
using System.Collections;



 
 public class StateManager {

    private JumpState jump;
    private IdleState idle;
    private RunState run;
    
    private IState currentState;
    private IState nextState;
    private IState defaultIdle;
    private IPlayerControl player;

 //   private bool bJumping = false;

    public StateManager(IPlayerControl _player) {
        player = _player;
        defaultIdle = new IdleState(player);
        currentState = defaultIdle;
        nextState = defaultIdle; 
    }  
    void SetState(IState state)
    {
       
    }

    public void SetIdleState()
    {
        //  if (preState is IdleState || bJumping == true)

        if (currentState is IdleState)
            return;
        // SetState(idle);
        SetState(new IdleState(player));
    }
    public void SetRunState()
    {
        //if (preState is RunState || bJumping == true)
        if (currentState is RunState)
            return;
        SetState(new RunState(player));
    }
    public void SetJumpState()
    {

        Debug.Log("jump State occurred");
        if (currentState is JumpState)
            return;
        SetState(new JumpState(player));
    }

    public void onUpdate() {
        //preState.OnUpdate();
    }
    
}

