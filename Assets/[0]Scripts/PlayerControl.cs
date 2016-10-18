using UnityEngine;
using System.Collections;
using System;

//attack hit dead + priority???

/*
    우선순위
    IDLE, RUN
    ATTACK, JUMP //공격 전 프로젝트 하던거 처럼  PREFAB
    HIT
    DEAD

 */



public interface IPlayerControl
{
    void PlayAnimation(string aniName);
    bool IsAnimationOver(string aniName, float timeCount = 1f);
    void CollisionOff();
    void CollisionOn();

    bool Jumping { get; set; }
}

public class PlayerControl : MonoBehaviour, IPlayerControl
{

    public float speed = 3.0F;
    public float rotateSpeed = 3.0F;

    CharacterController controller;
    public Animator animator;
    private IState mState;

    private IState m_next_state;
    /*JumpState jump;
    IdleState idle;
    RunState run;*/

    StateManager stateManager;

    private bool bJumping = false;

    public bool Jumping
    {
        get { return bJumping; }
        set { bJumping = value; }
    }
  /*  public bool Dead
    {
        get { return bJumping; }
        set { bJumping = value; }
    }*/

    public delegate void OnNotifyGotItem(int itemCode); //InputManager.
    public static event OnNotifyGotItem onNotifyGotItemE;

    public GameManager gameManager;

    void Awake()
    {
        animator = GetComponent<Animator>();
        //  jump = new JumpState(this);
        //  idle = new IdleState(this);
        //  run = new RunState(this);
        stateManager = new StateManager(this);

        gameManager = FindObjectOfType<GameManager>();

    }
    void Start()
    {
        //this.gameObject.GetComponent<CharacterController>();
        controller = GetComponent<CharacterController>();
        //  mState = idle;
    }


    //Observer
    public void OnTriggerEnter(Collider other)
    {
        
        if(other.tag == "ITEMA")
        {
            print("col ITEMA");

            ICommonItem aItem = other.gameObject.GetComponent<ICommonItem>();

            //gameManager.GotAItem(aItem);
            
            onNotifyGotItemE(aItem.GotItem());

        }
    }

    void Update()
    {

        transform.Rotate(0, Input.GetAxis("Horizontal") * rotateSpeed, 0);
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        float curSpeed = speed * Input.GetAxis("Vertical");
        controller.SimpleMove(forward * curSpeed);

        //  mState.OnUpdate();


        if (controller != null)
        {
            //controller.velocity
            Vector3 horiVec = new Vector3(controller.velocity.x, 0, controller.velocity.z);
            if (horiVec.magnitude != 0)
            {
                stateManager.SetRunState();
            }
            else
            {
                //SetState(idle);
                // stateManager.SetIdleState(this);
                stateManager.SetIdleState();
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                stateManager.SetJumpState();
            }

        }


        //AniTester();



    }
    #region Before Making stateManager
    /*  void SetState(IState state) {



          mState.OnEnd();
          mState = state;
          mState.OnStart();
      }

      private void SetIdleState()
      {
          if (mState is IdleState || bJumping == true )
              return;
          SetState(idle);
      }
      private void SetRunState()
      {
          if (mState is RunState || bJumping == true)
              return;
          SetState(run);
      }
      private void SetJumpState()
      {

          Debug.Log("jump State occured");
          if (mState is JumpState)
              return;
          SetState(jump);
      }


      */
    #endregion

    private void AniTester()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            //animator.Play("IDLE");
            //  SetState(idle);
            stateManager.SetIdleState();
        }
        else if (Input.GetKeyDown(KeyCode.X))
        {
            // animator.Play("RUN");
            // SetState(run);
            stateManager.SetRunState();

        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            // animator.Play("JUMP");
            // SetState(jump);
            stateManager.SetJumpState();
        }
    }




    #region IPlayerScript Interface Method


    public void PlayAnimation(string aniName)
    {
        animator.Play(aniName);
    }

    public void CollisionOff()
    {
        controller.detectCollisions = false;


    }

    public void CollisionOn()
    {
        controller.detectCollisions = true;
    }

    public bool IsAnimationOver(string aniName, float timeCount = 1f)
    {
        AnimatorStateInfo aniSI = animator.GetCurrentAnimatorStateInfo(0);

        //aniSI.IsName(ani)
        //aniSI.normalizedTime
        if (aniSI.IsName(aniName) && aniSI.normalizedTime >= timeCount)
        {
            return true;
        }
        else
            return false;
    }
    #endregion
}
