public class CS_Pause : CFSM_BaseState
{
    CFSM_BaseState _previousState;



    public CS_Pause(Character_FSM state_machine) : base(state_machine) { }

    //public override void Enter(CFSM_BaseState previous_state)
    //{
        //_previousState = previous_state;
    //}

    public override void Exit()
    {
        //_stateMachine.SetState<_previousState>();
    }
}
