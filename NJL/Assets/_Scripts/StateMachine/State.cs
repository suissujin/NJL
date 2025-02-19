using UnityEngine;
using UnityEngine.Events;

public abstract class State
{
    public State(StateMachine sm)
    {
        stateMachine = sm;
    }
    protected StateMachine stateMachine;
    public virtual void Enter() { }
    public virtual void Process() { }
    public virtual void FixedProcess() { }
    public virtual void Exit() { }
}
