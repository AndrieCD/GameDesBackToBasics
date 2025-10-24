using UnityEngine;

/// <summary>
/// Demonstrates a simple game menu using Unity's legacy GUI class.
/// Explains GUI controls, layout, and state management.
/// </summary>
public class GameMenuScript : MonoBehaviour
{
    // State variables for menu navigation
    private bool cOption, cStart;
    private int genderIndex;
    private string[] genders = { "Male", "Female" };
    private string name, nickname;
    private int ageSlider;

    [SerializeField] GUISkin guiSkin;   // Custom GUI skin for styling

    /// <summary>
    /// Called once before the first frame update.
    /// Initializes menu state and default values.
    /// </summary>
    private void Start( )
    {
        /*
        ============================================================
         🧠 UNITY GUI (LEGACY) TIPS & TRICKS
        ============================================================

         • The GUI class is *immediate mode* — it redraws the entire UI every frame.
           That means your OnGUI() function runs multiple times per frame
           (once for layout, once for input, once for rendering).

         • GUI elements (like Button, Box, Label) are not GameObjects — 
           they exist only during the current frame and are redrawn each call.

         • Always keep logic simple inside OnGUI(). Avoid physics or heavy loops.
           Use flags or simple booleans to control what’s visible.

         • Rect(x, y, width, height) uses *screen coordinates* in pixels.
           - (0,0) is the top-left corner of the screen.
           - Use Screen.width and Screen.height for dynamic positioning:
               Example: new Rect(Screen.width / 2 - 50, Screen.height / 2 - 25, 100, 50)

         • Use GUI.enabled = false; to temporarily disable interactive elements.

         • GUI.skin allows you to customize the look (fonts, colors, etc.)
           without modifying every control individually.

         • Avoid changing data directly in GUI controls every frame.
           Instead, store values in variables and render them.

         • OnGUI() is great for debugging tools, quick editors, or prototypes.

        ============================================================
        */



        cOption = false;
        cStart = false;
        genderIndex = 0;
        name = "";
        nickname = "";
        ageSlider = 10;
    }

    /// <summary>
    /// Called once per frame.
    /// Typically used for input or animation, not needed for static GUI.
    /// </summary>
    private void Update( )
    {
        // No logic needed for static menu
    }

    /// <summary>
    /// Called for rendering and handling GUI events.
    /// Demonstrates various GUI controls and layout.
    /// </summary>
    private void OnGUI( )
    {
        // Main Menu
        if (!cStart && !cOption)
        {
            // GUI.Box: Draws a box with a title
            GUI.Box(new Rect(0, 0, 350, 150), "Main Menu");

            // GUI.Button: Returns true if clicked
            cStart = GUI.Button(new Rect(50, 100, 50, 25), "Start");
            cOption = GUI.Button(new Rect(150, 100, 50, 25), "Option");
            GUI.Button(new Rect(250, 100, 50, 25), "Exit"); // No exit logic for demo
        }
        // Option Menu
        else if (cOption)
        {
            GUI.Box(new Rect(0, 0, 400, 350), "Option");

            // GUI.Toolbar: Select between options (returns selected index)
            genderIndex = GUI.Toolbar(new Rect(100, 50, 150, 50), genderIndex, genders);

            // GUI.Label: Displays static text
            GUI.Label(new Rect(50, 100, 100, 25), "Name:");
            name = GUI.TextField(new Rect(50, 125, 100, 25), name);

            GUI.Label(new Rect(200, 100, 100, 25), "Nickname:");
            nickname = GUI.TextField(new Rect(200, 125, 100, 25), nickname);

            GUI.Label(new Rect(50, 175, 300, 50), "Age: " + ageSlider);

            // GUI.HorizontalSlider: Select a value by sliding (returns float)
            // Cast to int for age
            ageSlider = (int) GUI.HorizontalSlider(new Rect(50, 225, 300, 50), ageSlider, 10, 65);

            // OK Button to return to main menu
            if (GUI.Button(new Rect(175, 275, 50, 25), "OK"))
                cOption = false;
        }
        // Information Screen
        else if (cStart)
        {
            // Prevent showing info if name is empty
            if (string.IsNullOrEmpty(name))
            {
                cStart = false;
                return;
            }

            GUI.Box(new Rect(0, 0, 350, 150), "Information");
            GUI.Label(new Rect(50, 25, 300, 25), "Gender: " + genders[genderIndex]);
            GUI.Label(new Rect(50, 50, 300, 25), "Name: " + name);
            GUI.Label(new Rect(50, 75, 300, 25), "Nickname: " + nickname);
            GUI.Label(new Rect(50, 100, 300, 25), "Age: " + ageSlider);
        }
    }
}
