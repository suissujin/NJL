using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StateMachine
{
    public State currentState;
    public Dictionary<string, State> states = new Dictionary<string, State>();
    public StateMachine(State initialState)
    {
        currentState = initialState;
        AddState(initialState);
    }

    public void ChangeState(string newState)
    {
        var state = states[newState];
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
        state.OnStateChanged.AddListener(ChangeState);
        states.Add(state.GetType().Name, state);
    }
}
