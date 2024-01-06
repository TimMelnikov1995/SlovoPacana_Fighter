using System;
using System.Collections.Generic;

public abstract class FinishStateMachine
{
    private FSM_BaseState _currentState { get; set; }

    private Dictionary<Type, FSM_BaseState> _states = new();

    public void AddState<T>(T state) where T : FSM_BaseState
    {
        _states.Add(state.GetType(), state);
    }

    public void SetState<T>() where T : FSM_BaseState
    {
        var type = typeof(T);

        if (_currentState != null && _currentState.GetType() == type)
            return;

        if (_states.TryGetValue(type, out var newState))
        {
            _currentState?.Exit();

            _currentState = newState;

            _currentState.Enter();
        }
    }

    public abstract void Update();
}