using PlayerState;
using UnityEngine;

namespace Employee
{
    public class PatrolState : State
    {
        readonly EmployeeBehaviour Employee;

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
            if (Employee.player.interactionStateMachine.currentState.GetType() == typeof(BrowsingState) ||
                Employee.player.interactionStateMachine.currentState.GetType() == typeof(HoldingState))
                Employee.stateMachine.ChangeState<SwarmState>();
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