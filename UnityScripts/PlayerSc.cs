using UnityEngine;
using UnityEngine.InputSystem;

/// <summary>
/// Handles player movement, shooting, reloading, and interaction
/// using Unity’s Input System and CharacterController.
/// </summary>
public class PlayerSc : MonoBehaviour
{
    // Reference to Unity's CharacterController component,
    // which allows smooth, collision-aware movement.
    [SerializeField] CharacterController charController;

    // Reference to the Input Action Asset (contains all the player input maps and actions).
    [SerializeField] InputActionAsset inputAction;

    // Prefab of the bullet to instantiate when the player shoots.
    [SerializeField] GameObject bulletPrefab;

    // Transform or GameObject representing the location (and rotation)
    // where bullets will be spawned when shooting.
    [SerializeField] GameObject bulletLoc;

    // Reference to the GameController script that manages overall game state.
    [SerializeField] GameController gameController;

    // InputActions for movement and looking (fetched from the InputActionAsset).
    InputAction move, look;

    // Speed multiplier for player movement.
    [SerializeField] float moveSpeed = 20f;

    // Stores current input values from keyboard/mouse or controller.
    Vector2 moveInput, lookInput;

    // Used to calculate and apply the final movement vector in world space.
    Vector3 moveVector;

    // Gravity strength (manual gravity simulation for the CharacterController).
    float gravity = 9.8f;

    // Handles vertical motion (falling or grounded state).
    Vector3 verticalMove = Vector3.up;

    // Player’s starting position (used for respawn if they fall off the map).
    Vector3 originalPosition;

    // Player's ammo count for shooting.
    int ammo = 10;

    // Public property to get/set ammo from other scripts.
    public int Ammo { get => ammo; set => ammo = value; }

    // Alternative way to access ammo (for demonstration of function-based getter).
    public int GetAmmo( )
    {
        return ammo;
    }

    // Called once when the game starts.
    // Stores the player's original spawn position for future respawns.
    void Start( )
    {
        originalPosition = transform.position;
    }

    private void OnEnable( )
    {
        // Get and enable the "Player" action map from the InputActionAsset.
        InputActionMap map = inputAction.FindActionMap("Player");
        map.Enable( );

        // Fetch the "Move" and "Look" input actions from the map.
        move = map.FindAction("Move");
        look = map.FindAction("Look");

        // Register functions to respond when the "Attack" or "Reload" inputs are triggered.
        map.FindAction("Attack").performed += Shoot_e;
        map.FindAction("Reload").performed += Reload_e;
    }

    // Called when the Reload input action is triggered.
    private void Reload_e(InputAction.CallbackContext obj)
    {
        // Only allow reloading when the game is active.
        if (!gameController.IsOk) return;

        // Resets ammo to full (10 bullets).
        ammo = 10;
    }

    // Called when the Attack (shoot) input action is triggered.
    private void Shoot_e(InputAction.CallbackContext obj)
    {
        // Only allow shooting when the game is active.
        if (!gameController.IsOk) return;

        // Prevent shooting if there’s no ammo left.
        if (Ammo <= 0) return;

        // Create a bullet at the specified location and rotation.
        Instantiate(bulletPrefab, bulletLoc.transform.position, bulletLoc.transform.rotation);

        // Reduce ammo by 1 after shooting.
        Ammo--;
    }

    private void OnDisable( )
    {
        // Disable the "Player" input map when this object is disabled
        // (helps avoid memory leaks or ghost input events).
        inputAction.FindActionMap("Player").Disable( );
    }

    // FixedUpdate is used for consistent movement updates (physics-related timing).
    private void FixedUpdate( )
    {
        // Only process input and movement when the game is running.
        if (gameController.IsOk)
        {
            // Handles player movement using input from the "Move" action.
            // Read movement input (WASD or joystick) and apply speed/time scaling.
            moveInput = move.ReadValue<Vector2>( ) * Time.deltaTime * moveSpeed;

            // If the player is on the ground, reset vertical motion.
            if (charController.isGrounded)
            {
                verticalMove.y = 0f;
            } else
            {
                // Apply gravity when not grounded.
                verticalMove.y -= gravity * Time.deltaTime;
            }

            // Convert movement from local to world space (so "forward" means forward relative to player rotation).
            moveVector = transform.TransformDirection(new Vector3(moveInput.x, verticalMove.y, moveInput.y));

            // Move the player using CharacterController (handles collisions automatically).
            charController.Move(moveVector);


            // Handles player rotation using input from the "Look" action.
            // Read mouse/controller input for looking.
            lookInput = look.ReadValue<Vector2>( );

            // Rotate the player horizontally (Y-axis) based on mouse X movement.
            transform.Rotate(0f, lookInput.x, 0f);
        }

        // Check if the player fell off the map and respawn if necessary.
        // Teleports the player back to the starting position if they fall too low.
        if (transform.position.y < -50f)
            transform.position = originalPosition;
    }

    // Allows external scripts to change the player’s material color.
    public void SetPlayerColor(Color newColor)
    {
        // Get the player’s MeshRenderer and apply the new color to its material.
        MeshRenderer meshRenderer = GetComponent<MeshRenderer>( );
        meshRenderer.material.color = newColor;
    }

    // Detects collisions between the CharacterController and other objects.
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        // Get the GameObject that the player collided with.
        GameObject objectHit = hit.gameObject;

        // If the player collides with an object named "finalPlatform",
        // notify the GameController that the final area has been reached.
        if (objectHit.name == "finalPlatform")
        {
            gameController.FinalPlatformReached( );
        }
    }

    // Regular Update method (currently unused).
    // Can be used later for per-frame visual effects, UI updates, etc.
    void Update( )
    {

    }
}
