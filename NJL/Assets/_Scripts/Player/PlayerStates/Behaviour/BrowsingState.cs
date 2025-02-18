using UnityEngine;

namespace PlayerState
{
    public class BrowsingState : State
    {
        private PlayerController Player;
        public BrowsingState(PlayerController player)
        {
            Player = player;
        }

        public override void Enter()
        {
            Debug.Log("Entering Browsing State");
        }
        public override void Process()
        {
            if (!Player.isBrowsing)
            {
                {
                    ChangeState("NotBrowsingState");
                }
            }
            if (Player.isHoldingItem)
            {
                ChangeState("HoldingState");
            }
        }

        public override void FixedProcess()
        {
            base.FixedProcess();
        }

        public override void Exit()
        {
            Debug.Log("Exiting Browsing State");
        }
    }
}