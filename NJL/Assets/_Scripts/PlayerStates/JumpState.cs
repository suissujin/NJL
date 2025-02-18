using UnityEngine;

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
        Player.verVelocity = Player.jumpForce * Vector3.up;
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
        Player.verVelocity = Vector3.zero;
    }
}
