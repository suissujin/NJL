using UnityEngine;

namespace Customer
{
    public class IdleState : State
    {
        CustomerBehaviour Customer;
        public IdleState(CustomerBehaviour customer)
        {
            Customer = customer;
        }
        public override void Enter()
        {
            Debug.Log("Entering Idle State");
        }
        public override void Process()
        {

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