using UnityEngine;

namespace Employee
{
    public class PatrolState : State
    {
        EmployeeBehaviour Employee;
        public PatrolState(EmployeeBehaviour employee, StateMachine stateMachine) : base(stateMachine)
        {
            Employee = employee;
        }
        public override void Enter()
        {
            Debug.Log("Entering Patrol State");
        }
        public override void Process()
        {
            if (Employee.player.locomotionStateMachine.currentState.GetType() == typeof(PlayerState.BrowsingState) || Employee.player.locomotionStateMachine.currentState.GetType() == typeof(PlayerState.HoldingState))
            {
                Employee.stateMachine.ChangeState<SwarmState>();
            }
        }
        public override void FixedProcess()
        {

        }
        public override void Exit()
        {
            Debug.Log("Exiting Patrol State");
        }
    }
}