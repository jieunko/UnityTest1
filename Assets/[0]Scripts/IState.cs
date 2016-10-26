using System.Collections;
using System;
using UnityEngine;
public enum Priority {
    IDLE, RUN, ATTACK, JUMP, DAMAGED, DEAD
}
public interface IState {
    int Prit { get; }
    bool Finish { get; }

    void OnStart();
    
    void OnUpdate();
    void OnEnd();
    //int returnPriority();
}

public class JumpState : IState {

    private IPlayerControl _player;
    private const string aniName = "JUMP";
    private bool bJmpEnd = false;

    public int Prit
    {
        get
        {
            return (int)Priority.JUMP;
        }
    }

    public bool Finish
    {
        get
        {
            return _player.IsAnimationOver(aniName);
        }
    }

    //private int prit = (int)Priority.JUMP;

    public JumpState(IPlayerControl player)
    {
        _player = player;
    }
    public void OnStart()
    {
        bJmpEnd = false;
        _player.PlayAnimation(aniName);
        _player.CollisionOff();
        _player.Jumping = true;
        Debug.Log("jump ani start");

    }

    public void OnEnd()
    {
        _player.CollisionOn();
        
    }

    void IState.OnUpdate()
    {
        if (bJmpEnd)
            return;

        if(_player.IsAnimationOver(aniName))
        {
            _player.Jumping = false;
            Debug.Log("jump ani end");
        }
    }

   /* public int returnPriority()
    {
        return prit;
    }*/
}

public class IdleState : IState {

    private IPlayerControl _player;
    private const string aniName = "IDLE";

    public int Prit
    {
        get
        {
            return (int)Priority.IDLE;
        }
    }

    public bool Finish
    {
        get
        {
            return _player.IsAnimationOver(aniName);
        }
    }
    //  private int prit = (int)Priority.IDLE;

    public IdleState(IPlayerControl iplayer) {

        _player = iplayer;
    }
    public void OnStart()
    {
        _player.PlayAnimation(aniName);
        
    }

    public void OnEnd()
    {
        
    }

    void IState.OnUpdate()
    {
        
    }

   /* public int returnPriority()
    {
        return prit;
    }*/
}

public class RunState : IState {

    private IPlayerControl _player;
    private const string aniName = "RUN";

    public int Prit
    {
        get
        {
            return (int)Priority.RUN;
        }
    }

    public bool Finish
    {
        get
        {
            return _player.IsAnimationOver(aniName);
        }
    }

    //private int prit = (int)Priority.RUN;


    public RunState(IPlayerControl iplayer) {
        _player = iplayer;
    }
    public void OnStart()
    {
        _player.PlayAnimation(aniName);
      
    }

    public void OnEnd()
    {
     
    }

    void IState.OnUpdate()
    {
        
    }

   /* public int returnPriority()
    {
        return prit;
    }*/
}

/*
 * public class AttackState : IState {
    private IPlayerControl _player;
    private const string aniName = "ATTACK";
    //public int prit = (int)Priority.ATTACK;

    public AttackState(IPlayerControl player) {
        _player = player;
    }
    public void OnStart()
    {
        _player.PlayAnimation(aniName);
    }

    public void OnUpdate()
    {
       
    }

    public void OnEnd()
    {
      
    }

   public int returnPriority()
    {
        return 0;
    }
}

public class Damaged : IState
{
    private IPlayerControl player;
    
    private const string aniName = "DAMAGED";
    public Damaged(IPlayerControl Iplayer) {
        player = Iplayer;
    }
    public void OnEnd()
    {
      
    }

    public void OnStart()
    {
        player.PlayAnimation(aniName);
    }

    public void OnUpdate()
    {
        
    }

    public int returnPriority()
    {
        return 0;
    }
}

public class Dead : IState {


    private IPlayerControl player;
    private const string aniName = "DEAD";
    private bool bDead = false;
    public void OnStart()
    {
        bDead = false;
        player.PlayAnimation(aniName);
    }

    public void OnUpdate()
    {
        if (bDead)
            return;

        if (player.IsAnimationOver(aniName, 2.5f))
        {
           // player.Jumping = false;

        }
    }

    public void OnEnd()
    {
     
    }

    public int returnPriority()
    {
        return 0;
    }
}
*/