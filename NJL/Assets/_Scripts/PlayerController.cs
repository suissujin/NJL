using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    PlayerInput playerInput;
    StateMachine stateMachine;
    public InputAction walkAction;
    public InputAction jumpAction;
    public InputAction lookAction;
    [SerializeField]
    CharacterController characterController;
    public Vector3 horVelocity = Vector3.zero;
    public Vector3 verVelocity = Vector3.zero;

    [SerializeField]
    public float speed = 5;
    public float yLookAngle = 0;
    public float jumpForce = 5;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        stateMachine = new StateMachine(new IdleState(characterController, this));
        stateMachine.AddState(new WalkState(characterController, this));
        stateMachine.AddState(new JumpState(characterController, this));

        playerInput = new PlayerInput();
        playerInput.Enable();
        walkAction = playerInput.FindAction("Walk");
        jumpAction = playerInput.FindAction("Jump");

        playerInput.Player.Look.performed += ctx => LookAround(ctx.ReadValue<Vector2>());
    }

    void Update()
    {
        if (!characterController.isGrounded)
        {
            //Debug.Log("Not Grounded");
            verVelocity.y += -9.8f * Time.deltaTime;
        }
        characterController.Move(verVelocity * Time.deltaTime);
        characterController.Move(speed * Time.deltaTime * transform.TransformDirection(horVelocity));
        stateMachine.Update();
    }
    void FixedUpdate()
    {
        stateMachine.FixedUpdate();
    }

    public void MovePlayer(Vector2 direction)
    {
        horVelocity = new Vector3(direction.x, 0, direction.y);
        Debug.Log(horVelocity);
    }

    void LookAround(Vector2 direction)
    {
        transform.Rotate(Vector3.up * direction.x);
        yLookAngle = Mathf.Clamp(yLookAngle - direction.y, -90, 90);
        Camera.main.transform.localRotation = Quaternion.Euler(yLookAngle, 0, 0);
    }
}
