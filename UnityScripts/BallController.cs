using UnityEngine;
using UnityEngine.InputSystem;

public class BallController : MonoBehaviour
{
    [Header("Input")]
    [SerializeField] private InputActionAsset inputAction;
    private InputAction attackAction;
    private InputAction interactAction;

    [Header("Ball Settings")]
    [SerializeField] private GameObject ball1;
    [SerializeField] private GameObject ball2;
    [SerializeField] private Transform ballCFrame; // position where ball sits
    [SerializeField] private float shootForce = 2000f;

    [Header("Rotation Settings")]
    [SerializeField] private float rotationDuration = 1f;
    private bool isRotating = false;
    private float rotationTimer = 0f;
    private Quaternion startRotation;
    private Quaternion targetRotation;

    private bool canShoot = true;

    private GameObject currentBall;

    public bool CanShoot { get => canShoot; set => canShoot =  value ; }

    private void Start( )
    {
        // If not assigned, find in scene (temporary fallback)
        if (ball1 == null) ball1 = GameObject.Find("Ball1");
        if (ball2 == null) ball2 = GameObject.Find("Ball2");
        if (ballCFrame == null) ballCFrame = GameObject.Find("BallCFrame").transform;

        currentBall = ball1;
    }

    private void OnEnable( )
    {
        var playerMap = inputAction.FindActionMap("Player");
        playerMap.Enable( );

        attackAction = playerMap.FindAction("Attack");
        interactAction = playerMap.FindAction("Interact");

        attackAction.performed += Shoot_e;
        interactAction.performed += Switch_e;
    }

    private void OnDisable( )
    {
        attackAction.performed -= Shoot_e;
        interactAction.performed -= Switch_e;

        inputAction.FindActionMap("Player").Disable( );
    }

    private void Shoot_e(InputAction.CallbackContext ctx)
    {
        if (isRotating || !CanShoot) return;

        var rb = currentBall.GetComponent<Rigidbody>( );
        rb.isKinematic = false;
        rb.AddRelativeForce(Vector3.forward * shootForce);
        CanShoot = false;
    }

    private void Switch_e(InputAction.CallbackContext ctx)
    {
        if (isRotating || !CanShoot) return;

        isRotating = true;
        rotationTimer = 0f;

        startRotation = transform.rotation;
        targetRotation = transform.rotation * Quaternion.Euler(0f, 180f, 0f);

        // Swap which ball is active
        currentBall = ( currentBall == ball1 ) ? ball2 : ball1;
    }

    private void FixedUpdate( )
    {
        if (isRotating)
        {
            rotationTimer += Time.deltaTime;    // increment timer
            float t = rotationTimer / rotationDuration; // calculate interpolation factor

            // Smooth rotation using Lerp
            transform.rotation = Quaternion.Lerp(startRotation, targetRotation, t);

            if (rotationTimer >= rotationDuration)
            {
                isRotating = false;
                rotationTimer = 0f;
            }
        }
    }
}
