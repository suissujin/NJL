using UnityEngine;
using UnityEngine.Events;

public abstract class State
{
    public UnityEvent<string> OnStateChanged = new UnityEvent<string>();
    public virtual void Enter() { }
    public virtual void Process() { }
    public virtual void FixedProcess() { }
    public virtual void Exit() { }
    protected void ChangeState(string stateName)
    {
        OnStateChanged.Invoke(stateName);
    }
}
