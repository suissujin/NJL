using UnityEngine;

namespace Employee
{
    public class SwarmState : State
    {
        EmployeeBehaviour Employee;
        public SwarmState(EmployeeBehaviour employee)
        {
            Employee = employee;
        }
        public override void Enter()
        {
            Debug.Log("Entering Idle State");
        }
        public override void Process()
        {
            Employee.transform.position = Vector3.MoveTowards(Employee.transform.position, Employee.player.transform.position, Employee.speed * Time.deltaTime);
            if (Employee.player.stateMachine.currentState.GetType() == typeof(PlayerState.NotBrowsingState))
            {
                Employee.stateMachine.ChangeState("IdleState");
            }
        }
        public override void FixedProcess()
        {

        }
        public override void Exit()
        {
            Debug.Log("Exiting Idle State");
        }
    }
}
