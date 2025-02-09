using UnityEngine;

public class PlayerController : MonoBehaviour
{
    PlayerInput playerInput;
    [SerializeField]
    CharacterController characterController;
    Vector3 moveDir = Vector3.zero;
    float yAngle = 0;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        playerInput = new PlayerInput();
        playerInput.Enable();
        playerInput.Player.Walk.performed += ctx => MovePlayer(ctx.ReadValue<Vector2>());
        playerInput.Player.Jump.performed += ctx => moveDir.y = 5;
        playerInput.Player.Look.performed += ctx => LookAround(ctx.ReadValue<Vector2>());
    }

    void Update()
    {
        if (!characterController.isGrounded)
        {
            moveDir.y -= 9.8f * Time.deltaTime;
        }
        characterController.Move(moveDir * Time.deltaTime);
    }

    void MovePlayer(Vector2 direction)
    {
        moveDir = new Vector3(direction.x, moveDir.z, direction.y);
    }

    void LookAround(Vector2 direction)
    {
        transform.Rotate(Vector3.up * direction.x);
        yAngle = Mathf.Clamp(yAngle - direction.y, -90, 90);
        Camera.main.transform.localRotation = Quaternion.Euler(yAngle, 0, 0);
    }
}
