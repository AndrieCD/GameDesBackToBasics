using UnityEngine;

public class GameController : MonoBehaviour
{
    /*
     * PRACTICE EXERCISE: Basic in-game GUI using Unity’s Immediate Mode GUI system.
     *
     * The goal is to create a small control panel that lets players:
     *   - Set a player name (TextField)
     *   - Choose a target count and target life (integer sliders)
     *   - Adjust color with RGB sliders
     *   - Confirm or reset their settings
     *   - Display the chosen settings once confirmed
     *
     * NOTE:
     * Unity’s GUI system (OnGUI) redraws every frame — like HTML elements being re-rendered constantly.
     * This is great for simple prototypes or debug tools, but not recommended for final UIs.
     */

    // Store screen halves (for simple centering)
    float ScreenWidthHalf = Screen.width / 2;
    float ScreenHeightHalf = Screen.height / 2;

    // GUI Variables
    float targetCount = 1;   // How many targets to spawn
    float targetLife = 1;    // Health of each target
    string playerName = "";  // Input field for player name
    float red = 255;
    float green = 255;
    float blue = 255;
    Color playerColor = Color.white; // Default color

    // Boolean flags (used for GUI state control)
    bool isConfirmed = false; // True when "Confirm" is pressed
    bool isReset = false;     // True when "Reset" is pressed
    bool isOk = false;        // True when player confirms final screen


    // SERIALIZE FIELD: For cleaner references in the Inspector
    // SerializeField for script and GameObject references
    [SerializeField] PlayerSc playerSc;
    [SerializeField] GameObject targetPrefab;

    // Object Tagging: Use tags to find objects in the scene
    GameObject[] targetPositions;


    void Start( )
    {
        // Usually for initialization, not needed for GUI logic

        // Find all target positions in the scene by tag
        targetPositions = GameObject.FindGameObjectsWithTag("TargetPosition");
    }

    // OnGUI() is called several times per frame when rendering and handling GUI events
    private void OnGUI( )
    {
        // ───────────────────────────────────────────────
        // 1. INPUT MENU (Default screen)
        // ───────────────────────────────────────────────
        if (!isConfirmed && !isOk)
        {
            // Draw a GUI box as the container/background
            GUI.Box(new Rect(ScreenWidthHalf / 2, ScreenHeightHalf / 2 - 30, ScreenWidthHalf, ScreenHeightHalf + 60),
                "Game Controller GUI");

            // --- Target Count ---
            // Label (shows current slider value dynamically)
            GUI.Label(new Rect(ScreenWidthHalf / 2 + 20, ScreenHeightHalf / 2 + 8, 200, 30), $"Target Count: {targetCount}");

            // Horizontal slider (1 to 4), rounded for integer snapping
            targetCount = GUI.HorizontalSlider(new Rect(ScreenWidthHalf / 2 + 120, ScreenHeightHalf / 2 + 10, 200, 30), targetCount, 1, 4);
            targetCount = Mathf.Round(targetCount);

            // --- Target Life ---
            GUI.Label(new Rect(ScreenWidthHalf / 2 + 20, ScreenHeightHalf / 2 + 40, 200, 30), $"Target Life: {targetLife}");
            targetLife = GUI.HorizontalSlider(new Rect(ScreenWidthHalf / 2 + 120, ScreenHeightHalf / 2 + 42, 200, 30), targetLife, 1, 3);
            targetLife = Mathf.Round(targetLife);

            // --- Player Name Input ---
            GUI.Label(new Rect(ScreenWidthHalf / 2 + 20, ScreenHeightHalf / 2 + 72, 200, 30), "Player Name:");
            playerName = GUI.TextField(new Rect(ScreenWidthHalf / 2 + 120, ScreenHeightHalf / 2 + 72, 200, 30), playerName);

            // --- Color Sliders ---
            // Display current RGB values from 0-255, rounded for integer snapping
            GUI.Label(new Rect(ScreenWidthHalf / 2 + 20, ScreenHeightHalf / 2 + 104, 300, 30), $"Player Color:");
            GUI.Label(new Rect(ScreenWidthHalf / 2 + 110, ScreenHeightHalf / 2 + 104, 50, 30), $"R:{red}");
            GUI.Label(new Rect(ScreenWidthHalf / 2 + 170, ScreenHeightHalf / 2 + 104, 50, 30), $"G:{green}");
            GUI.Label(new Rect(ScreenWidthHalf / 2 + 230, ScreenHeightHalf / 2 + 104, 50, 30), $"B:{blue}");
            red = GUI.VerticalSlider(new Rect(ScreenWidthHalf / 2 + 120, ScreenHeightHalf / 2 + 130, 20, 80), red, 255, 0);
            green = GUI.VerticalSlider(new Rect(ScreenWidthHalf / 2 + 180, ScreenHeightHalf / 2 + 130, 20, 80), green, 255, 0);
            blue = GUI.VerticalSlider(new Rect(ScreenWidthHalf / 2 + 240, ScreenHeightHalf / 2 + 130, 20, 80), blue, 255, 0);
            red = Mathf.Round(red);
            green = Mathf.Round(green);
            blue = Mathf.Round(blue);


            // --- Buttons ---
            // Returns true only on the frame the button is clicked
            isConfirmed = GUI.Button(new Rect(ScreenWidthHalf / 2 + 280, ScreenHeightHalf / 2 + 120, 100, 30), "Confirm");
            isReset = GUI.Button(new Rect(ScreenWidthHalf / 2 + 280, ScreenHeightHalf / 2 + 165, 100, 30), "Reset");
        }

        // ───────────────────────────────────────────────
        // 2. CONFIRMATION MENU
        // ───────────────────────────────────────────────
        // Only shown if Confirm button pressed and playerName is NOT empty
        if (isConfirmed && !string.IsNullOrEmpty(playerName) && !isOk)
        {
            // Box to hold confirmation details
            GUI.Box(new Rect(ScreenWidthHalf / 2, ScreenHeightHalf / 2 - 30, ScreenWidthHalf, ScreenHeightHalf + 30), "Confirm Details");

            // Display chosen settings
            GUI.Label(new Rect(ScreenWidthHalf / 2 + 20, ScreenHeightHalf / 2 + 8, 300, 30),
                $"Player Name: {playerName}");
            GUI.Label(new Rect(ScreenWidthHalf / 2 + 20, ScreenHeightHalf / 2 + 40, 300, 30),
                $"Target Count: {targetCount}");
            GUI.Label(new Rect(ScreenWidthHalf / 2 + 20, ScreenHeightHalf / 2 + 72, 300, 30),
                $"Target Life: {targetLife}");

            // OK Button — final confirmation
            isOk = GUI.Button(new Rect(ScreenWidthHalf / 2 + 65, ScreenHeightHalf / 2 + 140, 100, 30), "OK");

            // Back Button — return to input mode
            if (GUI.Button(new Rect(ScreenWidthHalf / 2 + 220, ScreenHeightHalf / 2 + 140, 100, 30), "Back"))
                isConfirmed = false;
        } else
        {
            // If name was empty, go back to input menu automatically
            isConfirmed = false;
        }

        // ───────────────────────────────────────────────
        // 3. RESET LOGIC
        // ───────────────────────────────────────────────
        if (isReset)
        {
            // Reset values to default
            targetCount = 1;
            targetLife = 1;
            playerName = "";

            // Important: turn off reset so it doesn't loop infinitely
            isReset = false;
        }

        // ───────────────────────────────────────────────
        // 4. OK LOGIC
        // ───────────────────────────────────────────────
        if (isOk)
        {
            // Set the player color based on RGB sliders (values 0-255 converted to 0-1)
            playerColor = new Color(red / 255f, green / 255f, blue / 255f);
            // Here you could apply the settings to your game (e.g., spawn targets, set player name/color, etc.)
            // @TODO:
            // Change player color
            // Spawn targets based on targetCount and targetLife

            // Note: When manipulating other game objects, ensure those objects/scripts are properly referenced
            // Make use of public methods or properties in those scripts to apply changes

            // Example: 
            // PlayerSc.SetPlayerColor(playerColor);    // PlayerSc is a serialized field reference to the PlayerSc script
                                                        // and SetPlayerColor is a public method you would define in that script
        }
    }

    // Custon Function to handle spawning targets
    void SpawnTargets(int count)
    {
        // Spawn targets based on the count parameter
        //for (int i = 0; i < count; i++)
        //{
        //    // Instantiate target prefab at position determined by targetPositions array
        //    foreach (GameObject pos in targetPositions)
        //    {
        //        // Instantitate a target at each position and rotation
        //        GameObject targetObj = Instantiate(targetPrefab, pos.transform.position, pos.transform.rotation);

        //        // Edit the target's life via its script
        //        TargetSc targetSc = targetObj.GetComponent<TargetSc>( );
        //        if (targetSc != null)
        //        {
        //            targetSc.SetLife(targetLife); // Assuming SetLife is a public method in TargetSc
        //        }
        //    }
        //}
    }

    void Update( )
    {
        // Empty for now — GUI logic handled in OnGUI()
        // Could later contain gameplay control logic tied to GUI data
    }
}
