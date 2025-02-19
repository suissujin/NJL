
using UnityEngine;

namespace PlayerState
{
    public class JumpState : State
    {
        private CharacterController CharacterController;
        private PlayerController Player;
        public JumpState(CharacterController characterController, PlayerController player)
        {
            CharacterController = characterController;
            Player = player;
        }
        public override void Enter()
        {
            Debug.Log("Entering Jump State");
            if (Player.groundTimer > 0)
            {
                Player.groundTimer = 0;
                Player.verVelocity += Mathf.Sqrt(Player.jumpForce * Player.gravity);
            }
        }

        public override void Process()
        {
            if (CharacterController.isGrounded)
            {
                ChangeState("IdleState");
            }
        }

        public override void FixedProcess()
        {
        }

        public override void Exit()
        {
            Debug.Log("Exiting Jump State");
            Player.verVelocity = 0;
        }
    }
}
