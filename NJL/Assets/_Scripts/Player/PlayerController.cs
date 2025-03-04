using PlayerState;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public InputAction walkAction;
    public InputAction jumpAction;
    public InputAction lookAction;
    public InputAction interactAction;
    public GameObject itemLookingAt;
    public GameObject itemHeld;
    public GameObject holdingPosition;
    public GameObject cameraDolly;

    [SerializeField] CharacterController characterController;

    public Vector3 horVelocity = Vector3.zero;
    public float verVelocity;

    public float browsingDistance = 5;
    public float speed = 5;
    public float yLookAngle;
    public float jumpForce = 5;
    public float gravity = 20;
    public float launchSpeed = 2;

    public float groundTimer;

    public bool isHoldingItem;
    public bool isBrowsing;

    [Range(0.01f, 1)] public float sensitivity;
    public Camera camera;

    public StateMachine interactionStateMachine;
    public StateMachine locomotionStateMachine;
    PlayerInput playerInput;
    public bool isGrounded => characterController.isGrounded && groundTimer <= 0;

    void Start()
    {
        camera = Camera.main;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        locomotionStateMachine = new StateMachine();
        locomotionStateMachine.AddState(new IdleState(characterController, this, locomotionStateMachine));
        locomotionStateMachine.AddState(new WalkState(characterController, this, locomotionStateMachine));
        locomotionStateMachine.AddState(new JumpState(characterController, this, locomotionStateMachine));
        locomotionStateMachine.SetState<IdleState>();

        interactionStateMachine = new StateMachine();
        interactionStateMachine.AddState(new NotBrowsingState(this, interactionStateMachine));
        interactionStateMachine.AddState(new BrowsingState(this, interactionStateMachine));
        interactionStateMachine.AddState(new HoldingState(this, interactionStateMachine));
        interactionStateMachine.SetState<NotBrowsingState>();

        playerInput = new PlayerInput();
        playerInput.Enable();
        walkAction = playerInput.FindAction("Walk");
        jumpAction = playerInput.FindAction("Jump");
        interactAction = playerInput.FindAction("Interact");

        playerInput.Player.Look.performed += ctx => LookAround(ctx.ReadValue<Vector2>() * sensitivity);
    }

    void Update()
    {
        locomotionStateMachine.Update();
        interactionStateMachine.Update();
        if (isGrounded)
            verVelocity = -1;
        else
            verVelocity -= gravity * Time.deltaTime;
        var velocity = transform.TransformDirection(horVelocity);
        velocity.y = verVelocity;
        characterController.Move(Time.deltaTime * velocity);

        if (Physics.Raycast(camera.transform.position, camera.transform.forward, out var hit,
                browsingDistance))
        {
            if (hit.transform.CompareTag("Item"))
            {
                itemLookingAt = hit.transform.gameObject;
                isBrowsing = true;
                Debug.Log("Looking at item");
            }
            else
            {
                itemLookingAt = null;
                isBrowsing = false;
            }
        }

        Debug.DrawRay(camera.transform.position, camera.transform.forward * browsingDistance, Color.red);

        if (groundTimer > 0) groundTimer -= Time.deltaTime;
    }

    void FixedUpdate()
    {
        locomotionStateMachine.FixedUpdate();
        interactionStateMachine.FixedUpdate();
    }

    void OnDrawGizmos()
    {
        if (!Application.isPlaying) return;
        Handles.Label(transform.position + Vector3.up * 3,
            "Locomotion State: " + locomotionStateMachine.currentState.GetType().Name);
        Handles.Label(transform.position + Vector3.up * 2,
            "Interaction State: " + interactionStateMachine.currentState.GetType().Name);
    }

    public void MovePlayer(Vector2 direction)
    {
        horVelocity = new Vector3(direction.x, 0, direction.y) * speed;
    }

    void LookAround(Vector2 direction)
    {
        transform.Rotate(Vector3.up * direction.x);
        yLookAngle = Mathf.Clamp(yLookAngle - direction.y, -90, 90);
        cameraDolly.transform.localRotation = Quaternion.Euler(yLookAngle, 0, 0);
    }
}