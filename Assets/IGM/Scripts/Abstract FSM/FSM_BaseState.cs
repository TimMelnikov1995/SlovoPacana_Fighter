public abstract class FSM_BaseState
{
    protected readonly FinishStateMachine _stateMachine;



    public FSM_BaseState(FinishStateMachine stateMachine)
    {
        _stateMachine = stateMachine;
    }

    public virtual void Enter() { }

    public virtual void Update() { }

    public virtual void Exit() { }
}