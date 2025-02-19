using UnityEngine;

namespace Customer
{
    public class PatrolState : State
    {
        CustomerBehaviour Customer;
        public PatrolState(CustomerBehaviour customer, StateMachine stateMachine) : base(stateMachine)
        {
            Customer = customer;
        }
        public override void Enter()
        {
            Debug.Log("Entering Patrol State");
        }
        public override void Process()
        {
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