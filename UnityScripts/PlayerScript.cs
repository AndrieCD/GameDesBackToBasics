using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{
    [Header("Input")]
    [SerializeField] private InputActionAsset inputAction;

    // Cache actions
    private InputAction moveAction;
    private InputAction lookAction;

    [Header("Movement")]
    [SerializeField] private float moveSpeed = 5f;            // units per second
    [SerializeField] private float gravityValue = -9.8f;     // gravity (m/s^2)
    private CharacterController characterController;
    private Vector3 verticalVelocity;                         // stores vertical velocity (y component)

    [Header("Look")]
    [SerializeField] private Camera playerCamera;
    [SerializeField] private float lookSensitivity = 100f;

    [Header("Respawn")]
    [SerializeField] private Transform respawnLocation;       // assign in inspector to avoid Find

    private void Start( )
    {
        characterController = GetComponent<CharacterController>( );

        // If playerCamera not set in Inspector, try Camera.main
        if (playerCamera == null)
            playerCamera = Camera.main;
    }

    private void OnEnable( )
    {
        InputActionMap actionMap = inputAction.FindActionMap("Player");
        actionMap.Enable( );

        // Cache actions
        moveAction = actionMap.FindAction("Move");
        lookAction = actionMap.FindAction("Look");
    }

    private void OnDisable( )
    {
        inputAction.FindActionMap("Player").Disable( );
    }

    void Update( )
    {
        HandleMove( );
        HandleLook( );
        CheckRespawn( );
    }

    private void HandleMove( )
    {
        Vector2 input = moveAction.ReadValue<Vector2>( );

        // Convert input (x,z) to world movement relative to player forward
        Vector3 move = transform.TransformDirection(new Vector3(input.x, 0f, input.y));
        Vector3 horizontal = move * moveSpeed * Time.deltaTime;

        // Gravity: if grounded reset vertical velocity, otherwise accumulate
        if (characterController.isGrounded && verticalVelocity.y < 0f)
        {
            verticalVelocity.y = 0f; // reset small negative velocity so character stays grounded
        } else
        {
            verticalVelocity.y += gravityValue * Time.deltaTime; // accumulate gravity
        }

        // Combine horizontal motion with vertical velocity
        Vector3 finalMove = horizontal + verticalVelocity;
        characterController.Move(finalMove);
    }

    private void HandleLook( )
    {
        Vector2 look = lookAction.ReadValue<Vector2>( ) * lookSensitivity * Time.deltaTime;

        // Yaw - rotate player around up axis
        transform.Rotate(0f, look.x, 0f);

    }

    private void CheckRespawn( )
    {
        if (transform.position.y < -20f)
        {
            if (respawnLocation != null)
                transform.position = respawnLocation.position;
            else
                Debug.LogWarning("Respawn location not set!");
        }
    }

}
