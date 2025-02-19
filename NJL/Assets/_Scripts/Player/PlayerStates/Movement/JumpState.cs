
using UnityEngine;

namespace PlayerState
{
    public class JumpState : State
    {
        private CharacterController CharacterController;
        private PlayerController Player;
        private Vector3 horizontalVelocity;
        public JumpState(CharacterController characterController, PlayerController player, StateMachine stateMachine) : base(stateMachine)
        {
            CharacterController = characterController;
            Player = player;
        }
        public override void Enter()
        {
            horizontalVelocity = Player.horVelocity;
            Debug.Log("Entering Jump State");
            if (Player.isGrounded)
            {
                Player.groundTimer = 0.25f;
                Player.verVelocity += Mathf.Sqrt(Player.jumpForce * Player.gravity);
            }
        }

        public override void Process()
        {
            horizontalVelocity *= 0.98f;
            Player.horVelocity = horizontalVelocity;
            if (CharacterController.isGrounded)
            {
                stateMachine.ChangeState<IdleState>();
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
