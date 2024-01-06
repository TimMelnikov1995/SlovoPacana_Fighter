public abstract class CFSM_BaseState// : FSM_BaseState
{
	protected readonly Character_FSM _stateMachine;



	public CFSM_BaseState(Character_FSM state_machine)
    {
        _stateMachine = state_machine;
    }

    public virtual void Enter() { }

    public virtual void Update() { }

    public virtual void Exit() { }



    protected bool IsOnGround()
    {
        return true;
    }
}
