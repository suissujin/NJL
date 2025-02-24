using Unity.VisualScripting;
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
            Player.itemHeld = Player.itemLookingAt;
            Player.itemHeld.transform.SetParent(Player.holdingPosition.transform);
            Player.itemHeld.transform.localPosition = Vector3.zero;
            Debug.Log("Entering Holding State");
        }

        public override void Process()
        {
            if (Player.interactAction.IsPressed())
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
            Player.holdingPosition.transform.DetachChildren();
            Player.itemHeld = null;
            Debug.Log("Exiting Holding State");
        }
    }
}
