using UnityEngine;

public class CustomerBehaviour : NPCBehaviour
{
    protected override void Start()
    {

        stateMachine = new();
        stateMachine.AddState(new Customer.IdleState(this, stateMachine));
        stateMachine.AddState(new Customer.PatrolState(this, stateMachine));

        stateMachine.SetState<Customer.IdleState>();
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
