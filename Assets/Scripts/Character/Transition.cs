public abstract class Transition
{
    protected Character_FSM _stateMachine;

    protected Transition(Character_FSM stateMachine)
    {
        _stateMachine = stateMachine;
    }

    public abstract void Update();
}
