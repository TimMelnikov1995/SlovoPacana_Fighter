using System.Collections.Generic;
using UnityEngine;

public class CS_Idle : CFSM_BaseState
{
    public CS_Idle(Character_FSM state_machine) : base(state_machine)
    {
        _transitions = new Transition[]
        {
            new ToJumping(_input, _stateMachine),
            //new ToCrouching(),
            //new ToBlocking(),
            //new ToAttacking(),
            new ToMoving(_input, _stateMachine),
        };
    }



    public override void Enter()
    {
        //Debug.Log("Idle state: [ENTER]");
    }

    public override void Update()
    {
        foreach (var transition in _transitions)
            transition.Update();

        ///if (_input.Jump)
            ///_stateMachine.SetState<CS_Jumping>();

        ///if (_stateMachine.characterInput.Crouch)
            ///_stateMachine.SetState<CS_Crouching>();

        ///if (_stateMachine.characterInput.Crouch)
            ///_stateMachine.SetState<CS_Blocking>();

        ///if (_stateMachine.characterInput.Crouch)
            ///_stateMachine.SetState<CS_Attacking>();

        ///if (_input.Horizontal_Move != 0)
            ///_stateMachine.SetState<CS_Moving>();
    }

    public override void FixedUpdate()
    {
        if (!IsOnGround())
            _stateMachine.SetState<CS_InAir>();
    }

    public override void Exit()
    {
        //Debug.Log("Idle state: [EXIT]");
    }
}
