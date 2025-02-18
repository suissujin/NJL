using UnityEngine;

public class CustomerBehaviour : NPCBehaviour
{
    protected override void Start()
    {
        stateMachine = new StateMachine(new Customer.IdleState(this));

        stateMachine.AddState(new Customer.PatrolState(this));
    }

    protected override void Update()
    {
        base.Update();
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }

}
