using UnityEngine;

public abstract class BaseState
{
	protected readonly StateMachine Fsm;

	public BaseState(StateMachine fsm)
	{
		Fsm = fsm;
	}

	public virtual void Enter() { }
    public virtual void Update() { }
    public virtual void Exit() { }
}
