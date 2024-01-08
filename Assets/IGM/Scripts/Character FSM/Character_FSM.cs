using System;
using System.Collections.Generic;
using UnityEngine;

public class Character_FSM// : FinishStateMachine
{
	public CharacterController characterController { get; }
    public CharacterAnimation characterAnimation { get; }
    public CharacterInput characterInput { get; }
	public Transform characterTransform { get; }

	private CFSM_BaseState _currentState { get; set; }

	private Dictionary<Type, CFSM_BaseState> _states = new ();

	public event Action<CFSM_BaseState> StateChanged; 



	public Character_FSM (CharacterController character_controller, CharacterAnimation character_animation, CharacterInput character_input, Transform character_transform)
	{
		characterController = character_controller;
		characterAnimation = character_animation;
		characterInput = character_input;
		characterTransform = character_transform;
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
}
