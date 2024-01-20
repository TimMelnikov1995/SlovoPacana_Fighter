using UnityEngine;

public class CS_Attacking : CFSM_BaseState
{
    public CS_Attacking(Character_FSM state_machine) : base(state_machine)
    {
        _transitions = new Transition[]
        {
            //new ToIdle(_input, _stateMachine),
            //new ToJumping(_input, _stateMachine),
            //new ToCrouching(_input, _stateMachine),
            //new ToRunning(_input, _stateMachine)
        };
    }



    public override void Enter()
    {
        Debug.Log("Attacking state: [ENTER]");

        //if (!IsOnGround())
            //Jump();

        //_stateMachine.SetState<CS_InAir>();
    }
}
