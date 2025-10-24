using UnityEngine;

public class BulletSc : MonoBehaviour
{
    // Rigidbody component reference — used to apply physics forces to the bullet
    [SerializeField] Rigidbody rigidBody;

    // Strength of the bullet’s forward force when fired
    [SerializeField] float force = 2000f;

    // ───────────────────────────────────────────────
    // Start() runs once when the bullet is first created (instantiated)
    // Handles initial movement and sets a self-destruct timer
    // ───────────────────────────────────────────────
    void Start( )
    {
        // Apply forward velocity so the bullet moves straight ahead
        // Vector3.forward refers to the local "forward" direction of the bullet prefab
        rigidBody.AddRelativeForce(Vector3.forward * force);

        // Ensure the bullet is affected by physics (not locked in place)
        rigidBody.isKinematic = false;

        // Automatically destroy the bullet after 2 seconds
        // This prevents unused bullets from staying in the scene forever
        Destroy(gameObject, 2f);
    }

    // ───────────────────────────────────────────────
    // Update() runs every frame — not used in this script
    // Could later be used for trail effects or homing behavior
    // ───────────────────────────────────────────────
    void Update( )
    {
        // Currently no per-frame logic needed
    }

    // ───────────────────────────────────────────────
    // OnCollisionEnter() is automatically called by Unity
    // whenever this bullet collides with another physical object (with a Collider)
    // Handles hit detection and target interaction
    // ───────────────────────────────────────────────
    private void OnCollisionEnter(Collision collision)
    {
        // Store the object that the bullet collided with
        GameObject objectHit = collision.gameObject;

        // Check if the collided object exists and is tagged as "Target"
        if (objectHit != null && objectHit.CompareTag("Target"))
        {
            // Get the TargetSc script component from the hit object
            TargetSc targetSc = objectHit.GetComponent<TargetSc>( );

            // If the target has the TargetSc script, apply effects
            if (targetSc != null)
            {
                // Deal 1 damage to the target
                targetSc.TakeDamage(1);

                // Change its color to a random color to show it was hit
                targetSc.ChangeToRandomColor( );
            }
        }

        // Destroy the bullet immediately after any collision
        // (Prevents multiple hits or bullets bouncing around)
        Destroy(gameObject);
    }
}
