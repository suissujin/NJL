using Unity.VisualScripting;
using UnityEngine;

public class EmployeeBehaviour : NPCBehaviour
{
    public float idleTimer = 5;
    public float speed = 5;
    protected override void Start()
    {
        base.Start();
        stateMachine = new StateMachine(new Employee.IdleState(this));
        stateMachine.AddState(new Employee.PatrolState(this));
        stateMachine.AddState(new Employee.SwarmState(this));
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
