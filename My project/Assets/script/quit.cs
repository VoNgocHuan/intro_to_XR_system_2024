using UnityEngine;

public class OculusQuitScript : MonoBehaviour
{
    // Use the appropriate KeyCode for the primary button on the Oculus Touch controller
    private KeyCode primaryButtonKeyCode = KeyCode.JoystickButton0; // This is typically the 'A' button on Oculus Touch

    void Update()
    {
        // Check if the primary button is pressed
        if (Input.GetButtonDown("Fire1")) // "Fire1" is a generic input name for the primary button
        {
            QuitGame();
        }
    }

    void QuitGame()
    {
        // Add any additional cleanup or game-ending logic here
        Debug.Log("Quitting game");

    #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
    #else
        Application.Quit();
    #endif
    }

}
