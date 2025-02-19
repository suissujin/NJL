using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    PlayerInput playerInput;
    public StateMachine stateMachine;
    public InputAction walkAction;
    public InputAction jumpAction;
    public InputAction lookAction;
    [SerializeField]
    CharacterController characterController;
    public Vector3 horVelocity = Vector3.zero;
    public float verVelocity;

    public float browsingDistance = 5;
    public float speed = 5;
    public float yLookAngle = 0;
    public float jumpForce = 5;
    public float gravity = 9.8f;

    public float groundTimer;

    public bool isHoldingItem;
    public bool isBrowsing;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        stateMachine = new StateMachine(new PlayerState.IdleState(characterController, this));
        stateMachine.AddState(new PlayerState.WalkState(characterController, this));
        stateMachine.AddState(new PlayerState.JumpState(characterController, this));
        stateMachine.AddState(new PlayerState.NotBrowsingState(this));
        stateMachine.AddState(new PlayerState.BrowsingState(this));
        stateMachine.AddState(new PlayerState.HoldingState(this));

        playerInput = new PlayerInput();
        playerInput.Enable();
        walkAction = playerInput.FindAction("Walk");
        jumpAction = playerInput.FindAction("Jump");

        playerInput.Player.Look.performed += ctx => LookAround(ctx.ReadValue<Vector2>());
    }

    void Update()
    {
        verVelocity -= gravity * Time.deltaTime;

        GroundCheck();
        characterController.Move(Time.deltaTime * transform.TransformDirection(horVelocity));
        stateMachine.Update();

        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out RaycastHit hit, browsingDistance))
        {
            if (hit.transform.CompareTag("Item"))
            {
                isBrowsing = true;
                Debug.Log("Looking at item");
            }
            else { isBrowsing = false; }
        }
        Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward * browsingDistance, Color.red);
        Debug.Log(characterController.isGrounded);
    }
    void FixedUpdate()
    {
        stateMachine.FixedUpdate();
    }

    public void MovePlayer(Vector2 direction)
    {
        horVelocity = new Vector3(direction.x, 0, direction.y);
    }

    void LookAround(Vector2 direction)
    {
        transform.Rotate(Vector3.up * direction.x);
        yLookAngle = Mathf.Clamp(yLookAngle - direction.y, -90, 90);
        Camera.main.transform.localRotation = Quaternion.Euler(yLookAngle, 0, 0);
    }

    void GroundCheck()
    {
        if (characterController.isGrounded) { groundTimer = 0.2f; }
        if (groundTimer > 0)
        {
            groundTimer -= Time.deltaTime;
        }
        if (characterController.isGrounded && verVelocity < 0)
        {
            verVelocity = 0;
        }
        horVelocity *= speed;
        horVelocity.y = verVelocity;
    }
}
