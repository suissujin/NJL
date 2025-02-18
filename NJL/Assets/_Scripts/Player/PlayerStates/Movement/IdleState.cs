using UnityEngine;

namespace PlayerState
{
    public class IdleState : State
    {

        private CharacterController CharacterController;
        private PlayerController Player;
        public IdleState(CharacterController characterController, PlayerController player)
        {
            CharacterController = characterController;
            Player = player;
        }
        public override void Enter()
        {
            Debug.Log("Entering Idle State");
        }

        public override void Process()
        {
            if (Player.walkAction.IsPressed())
            {
                ChangeState("WalkState");
            }
            if (Player.jumpAction.IsPressed())
            {
                ChangeState("JumpState");
            }
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
