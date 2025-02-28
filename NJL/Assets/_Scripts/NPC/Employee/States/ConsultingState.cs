using PlayerState;
using UnityEngine;

namespace Employee
{
    public class ConsultingState : State
    {
        readonly EmployeeBehaviour Employee;

        public ConsultingState(EmployeeBehaviour employee, StateMachine stateMachine) : base(stateMachine)
        {
            Employee = employee;
        }

        public override void Enter()
        {
            Debug.Log("Entering Consulting State");
        }

        public override void Process()
        {
            Employee.LookAtPlayer();
            if (Vector3.Distance(Employee.transform.position, Employee.player.transform.position) >
                Employee.talkingDistance)
                Employee.stateMachine.ChangeState<SwarmState>();
            if (Employee.player.interactionStateMachine.currentState.GetType() == typeof(NotBrowsingState))
                Employee.stateMachine.ChangeState<IdleState>();
        }

        public override void FixedProcess()
        {
            base.FixedProcess();
        }

        public override void Exit()
        {
            Debug.Log("Exiting Consulting State");
        }
    }
}