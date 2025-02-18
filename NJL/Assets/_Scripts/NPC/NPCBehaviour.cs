using UnityEngine;

public class NPCBehaviour : MonoBehaviour
{
    protected StateMachine stateMachine;

    protected virtual void Start()
    {

    }

    protected virtual void Update()
    {
        stateMachine.Update();
    }

    protected virtual void FixedUpdate()
    {
        stateMachine.FixedUpdate();
    }
}
