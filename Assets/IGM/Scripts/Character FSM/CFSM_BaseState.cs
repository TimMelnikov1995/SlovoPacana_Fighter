using UnityEngine;

public abstract class CFSM_BaseState// : FSM_BaseState
{
	protected readonly Character_FSM _stateMachine;
    protected Transition[] _transitions;



    protected CharacterController _controller => _stateMachine.characterScript.CharController;
    protected CharacterAnimation _animation => _stateMachine.characterScript.CharAnimation;
    protected CharacterInput _input => _stateMachine.characterScript.CharInput;



    public CFSM_BaseState(Character_FSM state_machine)
    {
        _stateMachine = state_machine;
    }

    public virtual void Enter() { }

    public virtual void Update() { }

    public virtual void FixedUpdate() { }

    public virtual void Exit() { }
}
