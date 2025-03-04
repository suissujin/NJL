using Unity.VisualScripting;
using UnityEngine;

namespace PlayerState
{
    public class HoldingState : State
    {
        readonly PlayerController Player;

        public HoldingState(PlayerController player, StateMachine stateMachine) : base(stateMachine)
        {
            Player = player;
        }

        public override void Enter()
        {
            Player.itemHeld = Player.itemLookingAt;
            Player.itemHeld.transform.SetParent(Player.holdingPosition.transform);
            Player.itemHeld.transform.localPosition = Vector3.zero;
            Player.itemHeld.transform.localRotation = Quaternion.identity;
            Player.itemHeld.GetComponent<Rigidbody>().isKinematic = true;
            Player.itemHeld.transform.GetChild(0).GameObject().layer = LayerMask.NameToLayer("FPSLayer");
            Debug.Log("Entering Holding State");
        }

        public override void Process()
        {
            if (Player.interactAction.WasPressedThisFrame())
            {
                if (Player.isBrowsing)
                    stateMachine.ChangeState<BrowsingState>();
                else
                    stateMachine.ChangeState<NotBrowsingState>();
            }
        }

        public override void FixedProcess()
        {
            //ragdoll physic shit
        }

        public override void Exit()
        {
            Player.holdingPosition.transform.DetachChildren();
            Player.itemHeld.transform.position = Player.cameraDolly.transform.position; 
            Player.itemHeld.GetComponent<Rigidbody>().isKinematic = false;
            Player.itemHeld.GetComponent<Rigidbody>().linearVelocity = Player.itemHeld.transform.forward * Player.launchSpeed;
            Player.itemHeld.transform.GetChild(0).GameObject().layer = LayerMask.NameToLayer("Default");
            Player.itemHeld = null;
            Debug.Log("Exiting Holding State");
        }
    }
}