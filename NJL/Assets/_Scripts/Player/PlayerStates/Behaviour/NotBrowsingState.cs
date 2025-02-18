using UnityEngine;

namespace PlayerState
{
    public class NotBrowsingState : State
    {
        private PlayerController Player;
        public NotBrowsingState(PlayerController player)
        {
            Player = player;
        }

        public override void Enter()
        {
            Debug.Log("Entering Not Browsing State");
        }

        public override void Process()
        {
            if (Player.isBrowsing)
            {
                ChangeState("BrowsingState");
            }
            else
            if (Player.isHoldingItem)
            {
                ChangeState("HoldingState");
            }
        }

        public override void FixedProcess()
        {
        }

        public override void Exit()
        {
            Debug.Log("Exiting Not Browsing State");
        }
    }
}
