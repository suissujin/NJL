using Unity.VisualScripting;
using UnityEngine;

public class EmployeeBehaviour : NPCBehaviour
{
    protected override void Start()
    {
        stateMachine = new StateMachine(new Employee.IdleState(this));

        stateMachine.AddState(new Employee.IdleState(this));
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
