using UnityEngine;

namespace Employee
{
    public class PatrolState : State
    {
        EmployeeBehaviour Employee;
        public PatrolState(EmployeeBehaviour employee)
        {
            Employee = employee;
        }
        public override void Enter()
        {
            Debug.Log("Entering Idle State");
        }
        public override void Process()
        {
            if (Employee.player.stateMachine.currentState.GetType() == typeof(PlayerState.BrowsingState))
            {
                Employee.stateMachine.ChangeState("SwarmState");
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