using UnityEngine;

public class StateMachine : MonoBehaviour
{
    private IState currentState;
    private IState initialState;

    private void Start()
    {
        currentState = initialState;
    }

    public void ChangeState(IState newState)
    {
        currentState.Exit();
        currentState = newState;
        currentState.Enter();
    }

    private void Update()
    {
        currentState.Update();
    }

    private void FixedUpdate()
    {
        currentState.FixedUpdate();
    }
}
