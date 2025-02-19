using UnityEngine;

namespace PlayerState
{
    public class IdleState : State
    {
        private CharacterController CharacterController;
        private PlayerController Player;
        public IdleState(CharacterController characterController, PlayerController player, StateMachine stateMachine) : base(stateMachine)
        {
            CharacterController = characterController;
            Player = player;
        }
        public override void Enter()
        {
            if (Player.walkAction.IsPressed())
            {
                stateMachine.ChangeState<WalkState>();
            }
            else { Player.horVelocity = Vector3.zero; }
            Debug.Log("Entering Idle State");
        }

        public override void Process()
        {
            if (Player.walkAction.IsPressed())
            {
                stateMachine.ChangeState<WalkState>();
            }
            if (Player.jumpAction.IsPressed())
            {
                stateMachine.ChangeState<JumpState>();
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
