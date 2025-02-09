using Unity.VisualScripting;
using UnityEngine;

public class PlayerWalkState : PlayerBaseState
{
    public override void Enter()
    {
        Debug.Log("PlayerWalkState Enter");
    }
    public override void Update()
    {
        Debug.Log("PlayerWalkState Update");
    }
    public override void FixedUpdate()
    {
        Debug.Log("PlayerWalkState FixedUpdate");
    }
    public override void Exit()
    {
        Debug.Log("PlayerWalkState Exit");
    }
}
