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
            Employee.CooldownTimer(Employee.idleTimer, () => Employee.stateMachine.ChangeState("PatrolState"));
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
            if (Employee.CRisRunning)
            {
                Employee.StopCoroutine(Employee.cooldown);
            }
            Debug.Log("Exiting Idle State");
        }
    }
}