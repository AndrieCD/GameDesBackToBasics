using UnityEngine;

public class BallScript : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Transform ballCFrame;
    [SerializeField] private BallController ballController;
    [SerializeField] private TargetWallScript targetWallScript;
    [SerializeField] private GameObject slidingWall;
    [SerializeField] private GameObject rotatingDoor;

    [Header("Sliding Wall Settings")]
    [SerializeField] private float openHeight = 4.75f;
    [SerializeField] private float slideSpeed = 0.1f;

    [Header("Rotating Door Settings")]
    [SerializeField] private Transform rotationPoint;
    [SerializeField] private float rotationDuration = 1f;
    [SerializeField] private float rotationAngle = -45f;

    private bool opening;
    private bool isRotating;
    private float rotationTimer;

    private void Start( )
    {
        // Fallback (still works if you forget to assign in Inspector)
        if (ballCFrame == null)
            ballCFrame = GameObject.Find("BallCFrame").transform;

        if (ballController == null)
            ballController = GameObject.Find("BallController").GetComponent<BallController>( );

        if (targetWallScript == null)
            targetWallScript = GameObject.Find("Target Wall").GetComponent<TargetWallScript>( );

        if (slidingWall == null)
            slidingWall = GameObject.Find("Sliding Wall");

        if (rotatingDoor == null)
            rotatingDoor = GameObject.Find("Rotating Door");

        // Color setup
        var mesh = GetComponent<MeshRenderer>( );
        mesh.material.color = ( name == "Ball1" ) ? Color.red : Color.blue;

        opening = false;
        isRotating = false;
        rotationTimer = 0f;
    }

    private void Update( )
    {
        // Handle sliding wall
        if (opening && slidingWall.transform.position.y < openHeight)
        {
            slidingWall.transform.Translate(Vector3.up * slideSpeed);
        }

        // Check for remaining targets
        if (!isRotating && GameObject.FindGameObjectsWithTag("Target").Length == 0)
        {
            Debug.Log("No more sphere targets!");
            isRotating = true;
            rotationTimer = 0f;
        }

        // Handle rotating door
        if (isRotating)
        {
            rotationTimer += Time.deltaTime;
            if (rotationTimer < rotationDuration)
            {
                rotatingDoor.transform.RotateAround(rotationPoint.position, Vector3.forward, rotationAngle * Time.deltaTime);
            } else
            {
                isRotating = false;
                rotationTimer = 0f;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Reset ball position
        transform.position = ballCFrame.position;
        transform.rotation = ballCFrame.rotation;
        ballController.CanShoot = true;

        // Reset physics
        var rb = GetComponent<Rigidbody>( );
        rb.isKinematic = true;

        GameObject hitObj = collision.gameObject;

        // Target Wall logic
        if (hitObj.name == "Target Wall")
        {
            if (IsMatchingColor(hitObj))
            {
                targetWallScript.Life--;
                Debug.Log("Life: " + targetWallScript.Life);
                if (targetWallScript.Life <= 0 && !opening)
                    opening = true;
            }
        }
        // Target Sphere logic
        else if (hitObj.CompareTag("Target"))
        {
            if (IsMatchingColor(hitObj))
                Destroy(hitObj);
        }
    }

    private bool IsMatchingColor(GameObject obj)
    {
        var ballColor = GetComponent<MeshRenderer>( ).material.color;
        var objColor = obj.GetComponent<MeshRenderer>( ).material.color;
        return ballColor == objColor;
    }
}
