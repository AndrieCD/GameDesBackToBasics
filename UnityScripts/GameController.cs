using UnityEngine;
using System.Collections.Generic;   // For using List<T>

/// <summary>
/// Handles all game setup, GUI controls, target spawning, and simple game state management.
/// Uses Unity’s Immediate Mode GUI (OnGUI) for interactive testing and settings.
/// </summary>
public class GameController : MonoBehaviour
{
    /*
     * 🧩 PRACTICE OVERVIEW:
     * This script demonstrates how to create a basic in-game GUI using Unity's Immediate Mode GUI system (OnGUI).
     * The GUI allows players to:
     *  - Set a player name.
     *  - Choose how many targets to spawn and their health.
     *  - Pick a custom color using RGB sliders.
     *  - Confirm or reset their choices.
     *  - Display chosen settings after confirmation.
     *
     * 💡 Note:
     * The OnGUI system is redrawn every frame — it’s great for quick prototypes or debug tools
     * but not recommended for polished UIs (use Canvas-based UI for that).
     */

    // Cached screen dimensions (used to center the GUI elements on screen)
    float ScreenWidthHalf = Screen.width / 2;
    float ScreenHeightHalf = Screen.height / 2;

    // ───────────────────────────────
    // GUI VARIABLES
    // ───────────────────────────────

    float targetCount = 1;       // How many targets to spawn
    float targetLife = 1;        // How many hits each target can take
    string playerName = "";      // Player name typed in a text field

    // RGB sliders for color customization (range 0–255)
    float red = 255;
    float green = 255;
    float blue = 255;
    Color playerColor = Color.white; // The resulting color applied to player

    // ───────────────────────────────
    // GUI STATE FLAGS
    // ───────────────────────────────
    bool isConfirmed = false;     // Becomes true when "Confirm" is clicked
    bool isReset = false;         // True when "Reset" is clicked
    bool isOk = false;            // True once the player confirms the final OK button

    // Track target spawning and progress
    bool targetsSpawned = false;  // To prevent spawning twice
    bool finalPlatformReached = false; // Used to show “You Win!” message later
    bool allTargetsDestroyed = false;  // Becomes true when all targets are gone

    // ───────────────────────────────
    // REFERENCES AND DATA STORAGE
    // ───────────────────────────────
    List<GameObject> targets = new List<GameObject>( ); // Stores all active target instances
    [SerializeField] PlayerSc playerSc;                // Reference to PlayerSc script
    [SerializeField] GameObject targetPrefab;          // Prefab used to spawn targets
    GameObject[] targetLoc;                            // Array of spawn locations (by tag)
    private string ammoCount;                          // Text display for ammo

    // Public property to share the OK state with other scripts (like PlayerSc)
    public bool IsOk { get => isOk; set => isOk = value; }

    // ───────────────────────────────
    // UNITY LIFECYCLE METHODS
    // ───────────────────────────────
    void Start( )
    {
        // Find all target spawn points in the scene by their tag "TargetLoc"
        targetLoc = GameObject.FindGameObjectsWithTag("TargetLoc");

        // Initialize ammo display string
        ammoCount = $"Ammo: {playerSc.GetAmmo( )}";
    }

    // ───────────────────────────────
    // GUI LOGIC
    // ───────────────────────────────
    private void OnGUI( )
    {
        // MAIN INPUT MENU (Default screen)
        // Shown at the start before confirmation
        if (!isConfirmed && !IsOk)  // Display this block if Confirmed and OK button has not been pressed
        {
            // Create a main box to contain all GUI elements
            GUI.Box(
                new Rect(ScreenWidthHalf / 2, ScreenHeightHalf / 2 - 30, ScreenWidthHalf, ScreenHeightHalf + 60),
                "Game Controller GUI"
            );

            // --- Target Count ---
            GUI.Label(new Rect(ScreenWidthHalf / 2 + 20, ScreenHeightHalf / 2 + 8, 200, 30),
                $"Target Count: {targetCount}");
            // Horizontal slider to select number of targets (1 to 4)
            targetCount = GUI.HorizontalSlider(new Rect(ScreenWidthHalf / 2 + 120, ScreenHeightHalf / 2 + 10, 200, 30),
                targetCount, 1, 4);
            targetCount = Mathf.Round(targetCount); // snap to whole numbers

            // --- Target Life ---
            GUI.Label(new Rect(ScreenWidthHalf / 2 + 20, ScreenHeightHalf / 2 + 40, 200, 30),
                $"Target Life: {targetLife}");
            // Horizontal slider to select target life (1 to 3)
            targetLife = GUI.HorizontalSlider(new Rect(ScreenWidthHalf / 2 + 120, ScreenHeightHalf / 2 + 42, 200, 30),
                targetLife, 1, 3);
            targetLife = Mathf.Round(targetLife);

            // --- Player Name Input ---
            GUI.Label(new Rect(ScreenWidthHalf / 2 + 20, ScreenHeightHalf / 2 + 72, 200, 30), "Player Name:");
            playerName = GUI.TextField(new Rect(ScreenWidthHalf / 2 + 120, ScreenHeightHalf / 2 + 72, 200, 30),
                playerName);

            // --- Color Sliders (RGB) ---
            GUI.Label(new Rect(ScreenWidthHalf / 2 + 20, ScreenHeightHalf / 2 + 104, 300, 30), "Player Color:");
            GUI.Label(new Rect(ScreenWidthHalf / 2 + 110, ScreenHeightHalf / 2 + 104, 50, 30), $"R:{red}");
            GUI.Label(new Rect(ScreenWidthHalf / 2 + 170, ScreenHeightHalf / 2 + 104, 50, 30), $"G:{green}");
            GUI.Label(new Rect(ScreenWidthHalf / 2 + 230, ScreenHeightHalf / 2 + 104, 50, 30), $"B:{blue}");

            // Each vertical slider controls one color channel (top = 0, bottom = 255)
            red = GUI.VerticalSlider(new Rect(ScreenWidthHalf / 2 + 120, ScreenHeightHalf / 2 + 130, 20, 80), red, 255, 0);
            green = GUI.VerticalSlider(new Rect(ScreenWidthHalf / 2 + 180, ScreenHeightHalf / 2 + 130, 20, 80), green, 255, 0);
            blue = GUI.VerticalSlider(new Rect(ScreenWidthHalf / 2 + 240, ScreenHeightHalf / 2 + 130, 20, 80), blue, 255, 0);
            red = Mathf.Round(red);
            green = Mathf.Round(green);
            blue = Mathf.Round(blue);

            // --- Buttons ---
            isConfirmed = GUI.Button(new Rect(ScreenWidthHalf / 2 + 280, ScreenHeightHalf / 2 + 120, 100, 30), "Confirm");
            isReset = GUI.Button(new Rect(ScreenWidthHalf / 2 + 280, ScreenHeightHalf / 2 + 165, 100, 30), "Reset");
        }

        // CONFIRMATION MENU — displays after "Confirm" is pressed
        if (isConfirmed && !string.IsNullOrEmpty(playerName) && !IsOk) // Make sure name is not empty
        {
            // Show confirmation box and chosen settings
            GUI.Box(new Rect(ScreenWidthHalf / 2, ScreenHeightHalf / 2 - 30, ScreenWidthHalf, ScreenHeightHalf + 30), "Confirm Details");
            GUI.Label(new Rect(ScreenWidthHalf / 2 + 20, ScreenHeightHalf / 2 + 8, 300, 30), $"Player Name: {playerName}");
            GUI.Label(new Rect(ScreenWidthHalf / 2 + 20, ScreenHeightHalf / 2 + 40, 300, 30), $"Target Count: {targetCount}");
            GUI.Label(new Rect(ScreenWidthHalf / 2 + 20, ScreenHeightHalf / 2 + 72, 300, 30), $"Target Life: {targetLife}");

            // "OK" button finalizes setup
            IsOk = GUI.Button(new Rect(ScreenWidthHalf / 2 + 65, ScreenHeightHalf / 2 + 140, 100, 30), "OK");

            // "Back" button returns to input menu
            if (GUI.Button(new Rect(ScreenWidthHalf / 2 + 220, ScreenHeightHalf / 2 + 140, 100, 30), "Back"))
                isConfirmed = false;
        } else
        {
            // If player name was empty, return automatically to input screen
            isConfirmed = false;
        }

        // RESET LOGIC — resets GUI inputs to defaults
        if (isReset)
        {
            targetCount = 1;
            targetLife = 1;
            playerName = "";
            isReset = false; // important to avoid looping
        }

        // FINAL CONFIRMATION (OK STATE)
        if (IsOk)
        {
            // Convert 0–255 RGB values to 0–1 color range
            playerColor = new Color(red / 255f, green / 255f, blue / 255f);

            // Apply chosen color to the player’s material
            playerSc.SetPlayerColor(playerColor);

            // Spawn targets once (only if not already done)
            if (!targetsSpawned)
                SpawnTargets((int)targetCount);

            // Display player name and ammo during gameplay
            GUI.Label(new Rect(50, 20, 200, 30), playerName);
            ammoCount = $"Ammo: {playerSc.GetAmmo( )}";
            GUI.Label(new Rect(50, 50, 200, 30), ammoCount);
        }

        // WIN MESSAGE
        if (finalPlatformReached)   // Show "You Win!" when player reaches final area
            GUI.Label(new Rect(ScreenWidthHalf, ScreenHeightHalf, 600, 80), "You Win!");
    }

    // ───────────────────────────────
    // TARGET SPAWNING
    // ───────────────────────────────
    void SpawnTargets(int count)
    {
        Debug.Log($"Spawning {count} targets...");

        // Loop through spawn points and create a target at each
        for (int i = 0; i < count; i++)
        {
            // Instantiate target prefab at spawn location
            GameObject pos = targetLoc[i];
            GameObject targetObj = Instantiate(targetPrefab, pos.transform.position, pos.transform.rotation);

            // Add spawned target to list
            targets.Add(targetObj);

            // Assign life value to target through its script
            TargetSc targetSc = targetObj.GetComponent<TargetSc>( );
            if (targetSc != null)
                targetSc.SetLife((int)targetLife);
        }

        // Prevent spawning again
        targetsSpawned = true;
        Debug.Log($"Targets spawned: {targets.Count}");
    }

    // Removes a target from the list when destroyed (called by TargetSc)
    public void RemoveFromList(GameObject removeItem)
    {
        targets.Remove(removeItem);
    }

    // ───────────────────────────────
    // UPDATE LOOP
    // ───────────────────────────────
    void Update( )
    {
        // Main gameplay checks happen here
        if (targetsSpawned)
        {
            // Check if all targets are gone
            if (targets.Count == 0)
                allTargetsDestroyed = true;

            // When all destroyed, allow player to climb higher
            if (allTargetsDestroyed)
                MakePlayerClimb( );
        }
    }

    // Called when player reaches final area
    public void FinalPlatformReached( )
    {
        finalPlatformReached = true;
    }

    // ───────────────────────────────
    // UTILITY FUNCTIONS
    // ───────────────────────────────
    // Allows player to climb a final step/platform by increasing stepOffset
    void MakePlayerClimb( )
    {
        if (playerSc != null)
        {
            CharacterController charController = playerSc.GetComponent<CharacterController>( );
            charController.stepOffset = 0.5f;
        }
    }
}
