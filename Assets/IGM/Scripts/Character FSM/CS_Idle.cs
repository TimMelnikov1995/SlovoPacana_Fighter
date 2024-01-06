using UnityEngine;

public class CS_Idle : CFSM_BaseState
{
    public CS_Idle(Character_FSM state_machine) : base(state_machine) { }



    public override void Enter()
    {
        Debug.Log("Idle state: [ENTER]");
    }

    public override void Exit()
    {
        Debug.Log("Idle state: [EXIT]");
    }

    public override void Update()
    {
        Debug.Log("Idle state: [UPDATE]");

        if (!IsOnGround())
            _stateMachine.SetState<CS_InAir>();

        Debug.Log(PlayerInput.Instance.horizontal_move);

        if (PlayerInput.Instance.horizontal_move != 0)
            _stateMachine.SetState<CS_Walking>();
    }
}
