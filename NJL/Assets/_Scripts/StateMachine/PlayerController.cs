using UnityEngine;

public class PlayerController : MonoBehaviour
{
    PlayerInput playerInput;
    [SerializeField]
    CharacterController characterController;
    Vector3 horVelocity = Vector3.zero;
    Vector3 verVelocity = Vector3.zero;

    [SerializeField]
    float speed = 5;
    float yLookAngle = 0;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        playerInput = new PlayerInput();
        playerInput.Enable();
        playerInput.Player.Walk.performed += ctx => MovePlayer(ctx.ReadValue<Vector2>());
        playerInput.Player.Jump.performed += ctx => verVelocity.y = 5;
        playerInput.Player.Look.performed += ctx => LookAround(ctx.ReadValue<Vector2>());
    }

    void Update()
    {
        if (!characterController.isGrounded)
        {
            verVelocity.y += -9.8f * Time.deltaTime;
        }
        characterController.Move(speed * Time.deltaTime * transform.TransformDirection(horVelocity));
        characterController.Move(verVelocity * Time.deltaTime);

    }

    void MovePlayer(Vector2 direction)
    {
        horVelocity = new Vector3(direction.x, horVelocity.z, direction.y);
    }

    void LookAround(Vector2 direction)
    {
        transform.Rotate(Vector3.up * direction.x);
        yLookAngle = Mathf.Clamp(yLookAngle - direction.y, -90, 90);
        Camera.main.transform.localRotation = Quaternion.Euler(yLookAngle, 0, 0);
    }
}
