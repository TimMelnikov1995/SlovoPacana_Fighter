using System;
using System.Collections.Generic;
using UnityEngine;

public class Character_FSM// : FinishStateMachine
{
    public CFSM_Script characterScript { get; }

    private CFSM_BaseState _currentState { get; set; }

	private Dictionary<Type, CFSM_BaseState> _states = new ();

	public event Action<CFSM_BaseState> StateChanged; 



	public Character_FSM(CFSM_Script script)
	{
        characterScript = script;
	}



	public void AddState(CFSM_BaseState state)
	{
		_states.Add(state.GetType(), state);
	}

	public void SetState<T>() where T : CFSM_BaseState
	{
		var type = typeof(T);

		if (_currentState != null && _currentState.GetType() == type)
			return;

		if (_states.TryGetValue(type, out var newState))
		{
			_currentState?.Exit();

			_currentState = newState;

			_currentState.Enter();

			StateChanged?.Invoke(_currentState);
		}
	}

	public void Update()
	{
		_currentState?.Update();
	}

	public void FixedUpdate()
	{
		_currentState?.FixedUpdate();
	}
}
