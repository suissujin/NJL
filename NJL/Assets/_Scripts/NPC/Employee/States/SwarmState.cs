using UnityEngine;

namespace Employee
{
    public class SwarmState : State
    {
        EmployeeBehaviour Employee;
        public SwarmState(EmployeeBehaviour employee, StateMachine stateMachine) : base(stateMachine)
        {
            Employee = employee;
        }
        public override void Enter()
        {
            Debug.Log("Entering Swarm State");
        }
        public override void Process()
        {
            Employee.transform.position = Vector3.MoveTowards(Employee.transform.position, Employee.player.transform.position, Employee.speed * Time.deltaTime);
            if (
                Vector3.Distance(Employee.transform.position, Employee.player.transform.position) < 1.5f)
            {
                Employee.stateMachine.ChangeState<ConsultingState>();
            }
            if (Employee.player.interactionStateMachine.currentState.GetType() == typeof(PlayerState.NotBrowsingState))
            {
                Employee.stateMachine.ChangeState<IdleState>();
            }
        }
        public override void FixedProcess()
        {

        }
        public override void Exit()
        {
            Debug.Log("Exiting Swarm State");
        }
    }
}
