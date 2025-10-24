using UnityEngine;

/// <summary>
/// Demonstrates basic camera setup and configuration in Unity.
/// Explains key Camera properties and usage.
/// </summary>
public class CameraScript : MonoBehaviour
{
    // Reference to the main camera in the scene
    private Camera myCamera;

    private void Start( )
    {
        // Camera.main returns the first enabled camera tagged "MainCamera"
        myCamera = Camera.main;


        // CameraClearFlags determines how the camera clears the screen before rendering
        // SolidColor clears the screen to a single color (set in the Camera component)
        myCamera.clearFlags = CameraClearFlags.SolidColor;
        myCamera.clearFlags = CameraClearFlags.Skybox; // Use skybox for background
        myCamera.clearFlags = CameraClearFlags.Depth; // Only clear depth buffer
        myCamera.clearFlags = CameraClearFlags.Nothing; // Do not clear anything


        // cullingMask controls which layers the camera renders
        // LayerMask.GetMask returns a bitmask for the specified layer names
        // Example: Render only layer A
        myCamera.cullingMask = 1 << LayerMask.NameToLayer("A");
        // Example: Render everything
        myCamera.cullingMask = ~0;
        // Example: Only render objects on layers "B" and "D" using bitwise operations
        myCamera.cullingMask  = ( 1 << LayerMask.NameToLayer("B") ) | ( 1 << LayerMask.NameToLayer("D") );
        // Example: Render all layers except layer "C"
        myCamera.cullingMask = ~( 1 << LayerMask.NameToLayer("C") );
        // Example: Render layers A, C, and E
        myCamera.cullingMask =  ( 1 << LayerMask.NameToLayer("A") ) |
                                ( 1 << LayerMask.NameToLayer("C") ) |
                                ( 1 << LayerMask.NameToLayer("E") );
        // Example: Render everything except UI and Background layers
        myCamera.cullingMask = ~(( 1 << LayerMask.NameToLayer("UI") ) |
                                ( 1 << LayerMask.NameToLayer("Background")) );


        // Set the background color (used when clearFlags is SolidColor)
        myCamera.backgroundColor = Color.cyan;


        // Set the field of view (vertical viewing angle, in degrees)
        myCamera.fieldOfView = 70f;


        // Set near and far clipping planes (distance range for rendering)
        myCamera.nearClipPlane = 0.1f;
        myCamera.farClipPlane = 500f;

        
        // Switch between perspective and orthographic projection
        myCamera.orthographic = false; // Set to true for 2D or top-down games
        myCamera.orthographicSize = 5f; // Only used if orthographic is true

        
        // Set camera depth (rendering order, higher renders on top)
        myCamera.depth = 1;

        
        // Set the viewport rect (portion of the screen the camera renders to)
        myCamera.rect = new Rect(0f, 0f, 1f, 1f); // Full screen

    }

    private void Update( )
    {

    }
}
