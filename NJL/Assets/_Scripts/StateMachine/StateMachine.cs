using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StateMachine
{
    public State currentState;
    public Dictionary<Type, State> states = new Dictionary<Type, State>();
    public bool IsCurrentStateOfType<T>() where T : State
    {
        return currentState.GetType() == typeof(T);
    }

    public void SetState<T>() where T : State
    {
        currentState = states[typeof(T)];
    }

    public void ChangeState<T>() where T : State
    {
        var state = states[typeof(T)];
        currentState.Exit();
        currentState = state;
        currentState.Enter();
    }

    public void Update()
    {
        currentState.Process();
    }

    public void FixedUpdate()
    {
        currentState.FixedProcess();
    }

    public void AddState(State state)
    {
        states.Add(state.GetType(), state);
    }
}
