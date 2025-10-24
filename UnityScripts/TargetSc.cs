using UnityEngine;

public class TargetSc : MonoBehaviour
{
    // Current life/health of the target
    int life = 1;

    // Reference to the GameController script to notify when this target is destroyed
    [SerializeField] GameController gameController;

    // ───────────────────────────────────────────────
    // Sets the initial life/health value for this target
    // Called by GameController after the target is spawned
    // ───────────────────────────────────────────────
    public void SetLife(int val)
    {
        life = val;
    }

    // ───────────────────────────────────────────────
    // Reduces the target’s life by a given value (damage)
    // If life reaches zero or below:
    //   - Notify the GameController to remove this target from its list
    //   - Destroy the GameObject from the scene
    // ───────────────────────────────────────────────
    public void TakeDamage(int val)
    {
        life -= val; // Subtract the incoming damage value

        if (life <= 0)
        {
            // Tell the GameController that this target no longer exists
            gameController.RemoveFromList(gameObject);

            // Remove the target from the scene entirely
            Destroy(gameObject);
        }
    }

    // ───────────────────────────────────────────────
    // Randomly changes the target’s color when hit
    // Uses Unity’s Random.value (returns 0–1) for RGB color values
    // Gives a visual indication that the target was hit
    // ───────────────────────────────────────────────
    public void ChangeToRandomColor( )
    {
        MeshRenderer meshRenderer = GetComponent<MeshRenderer>( );
        meshRenderer.material.color = new Color(Random.value, Random.value, Random.value);
    }

    // ───────────────────────────────────────────────
    // Start() runs once when the object is first created
    // Finds the GameController object in the scene and stores a reference to it
    // This allows the target to communicate back (e.g., when it’s destroyed)
    // ───────────────────────────────────────────────
    void Start( )
    {
        gameController = GameObject.Find("GameController").GetComponent<GameController>( );
    }

    // ───────────────────────────────────────────────
    // Update() runs once every frame
    // Currently not used, but could be extended for animations or effects
    // ───────────────────────────────────────────────
    void Update( )
    {
        // No behavior needed per frame for now
    }
}
