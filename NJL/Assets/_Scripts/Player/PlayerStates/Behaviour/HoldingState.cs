using UnityEngine;

namespace PlayerState
{
    public class HoldingState : State
    {
        private PlayerController Player;
        public HoldingState(PlayerController player, StateMachine stateMachine) : base(stateMachine)
        {
            Player = player;
        }

        public override void Enter()
        {
            //assing picked up object as child to player
            Debug.Log("Entering Holding State");
        }

        public override void Process()
        {
            if (!Player.isHoldingItem)
            {
                if (Player.isBrowsing)
                {
                    stateMachine.ChangeState<BrowsingState>();
                }
                else
                {
                    stateMachine.ChangeState<NotBrowsingState>();
                }
            }
        }

        public override void FixedProcess()
        {
            //ragdoll physic shit
        }

        public override void Exit()
        {
            //clear child object from player
            Debug.Log("Exiting Holding State");
        }
    }
}
