using UnityEngine;

namespace Employee
{
    public class IdleState : State
    {
        EmployeeBehaviour Employee;
        public IdleState(EmployeeBehaviour employee)
        {
            Employee = employee;
        }
        public override void Enter()
        {
            Debug.Log("Entering Idle State");
        }
        public override void Process()
        {
            Employee.CooldownTimer(Employee.idleTimer, () => Employee.stateMachine.ChangeState("PatrolState"));
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