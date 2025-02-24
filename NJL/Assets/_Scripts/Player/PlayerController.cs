using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.TextCore.Text;

public class PlayerController : MonoBehaviour
{
    PlayerInput playerInput;
    public StateMachine locomotionStateMachine;
    public StateMachine interactionStateMachine;
    public InputAction walkAction;
    public InputAction jumpAction;
    public InputAction lookAction;
    public InputAction interactAction;
    public GameObject itemLookingAt;
    public GameObject itemHeld;
    public GameObject holdingPosition;
    [SerializeField]
    CharacterController characterController;
    public Vector3 horVelocity = Vector3.zero;
    public float verVelocity;

    public float browsingDistance = 5;
    public float speed = 5;
    public float yLookAngle = 0;
    public float jumpForce = 5;
    public float gravity = 20;

    public float groundTimer;

    public bool isHoldingItem;
    public bool isGrounded => characterController.isGrounded && groundTimer <= 0;
    public bool isBrowsing;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        locomotionStateMachine = new();
        locomotionStateMachine.AddState(new PlayerState.IdleState(characterController, this, locomotionStateMachine));
        locomotionStateMachine.AddState(new PlayerState.WalkState(characterController, this, locomotionStateMachine));
        locomotionStateMachine.AddState(new PlayerState.JumpState(characterController, this, locomotionStateMachine));
        locomotionStateMachine.SetState<PlayerState.IdleState>();

        interactionStateMachine = new();
        interactionStateMachine.AddState(new PlayerState.NotBrowsingState(this, interactionStateMachine));
        interactionStateMachine.AddState(new PlayerState.BrowsingState(this, interactionStateMachine));
        interactionStateMachine.AddState(new PlayerState.HoldingState(this, interactionStateMachine));
        interactionStateMachine.SetState<PlayerState.NotBrowsingState>();

        playerInput = new PlayerInput();
        playerInput.Enable();
        walkAction = playerInput.FindAction("Walk");
        jumpAction = playerInput.FindAction("Jump");
        interactAction = playerInput.FindAction("Interact");

        playerInput.Player.Look.performed += ctx => LookAround(ctx.ReadValue<Vector2>());
    }

    void Update()
    {
        locomotionStateMachine.Update();
        interactionStateMachine.Update();
        if (isGrounded)
        {
            verVelocity = -1;
        }
        else
        {
            verVelocity -= gravity * Time.deltaTime;
        }
        Vector3 velocity = transform.TransformDirection(horVelocity);
        velocity.y = verVelocity;
        characterController.Move(Time.deltaTime * velocity);

        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out RaycastHit hit, browsingDistance))
        {
            if (hit.transform.CompareTag("Item"))
            {
                itemLookingAt = hit.transform.gameObject;
                isBrowsing = true;
                Debug.Log("Looking at item");
            }
            else { itemLookingAt = null; isBrowsing = false; }
        }
        Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward * browsingDistance, Color.red);

        if (groundTimer > 0)
        {
            groundTimer -= Time.deltaTime;
        }
    }
    void FixedUpdate()
    {
        locomotionStateMachine.FixedUpdate();
        interactionStateMachine.FixedUpdate();
    }

    public void MovePlayer(Vector2 direction)
    {
        horVelocity = new Vector3(direction.x, 0, direction.y) * speed;
    }

    void LookAround(Vector2 direction)
    {
        transform.Rotate(Vector3.up * direction.x);
        yLookAngle = Mathf.Clamp(yLookAngle - direction.y, -90, 90);
        Camera.main.transform.localRotation = Quaternion.Euler(yLookAngle, 0, 0);
    }

    void OnDrawGizmos()
    {
        Handles.Label(transform.position + Vector3.up * 3, "Locomotion State: " + locomotionStateMachine.currentState.GetType().Name);
        Handles.Label(transform.position + Vector3.up * 2, "Interaction State: " + interactionStateMachine.currentState.GetType().Name);
    }
}
