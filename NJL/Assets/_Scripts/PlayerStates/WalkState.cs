using UnityEngine;

public class WalkState : State
{
    private CharacterController CharacterController;
    private PlayerController Player;
    public WalkState(CharacterController characterController, PlayerController player)
    {
        CharacterController = characterController;
        Player = player;
    }
    public override void Enter()
    {
        Debug.Log("Entering Walk State");
    }

    public override void Process()
    {
        Player.MovePlayer(Player.walkAction.ReadValue<Vector2>());
        if (!Player.walkAction.IsPressed())
        {
            ChangeState("IdleState");
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
        Debug.Log("Exiting Walk State");
    }

}
