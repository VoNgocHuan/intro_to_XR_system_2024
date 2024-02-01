using UnityEngine;

public class OculusInteractionScript : MonoBehaviour
{
    // Use the appropriate KeyCode for the primary and secondary buttons on the Oculus Touch controller
    private KeyCode primaryButtonKeyCode = KeyCode.JoystickButton0; // 'A' button on Oculus Touch
    private KeyCode secondaryButtonKeyCode = KeyCode.JoystickButton1; // 'B' button on Oculus Touch

    // Reference to the point light component on the same GameObject
    private Light pointLight;

    void Start()
    {
        // Get the point light component during initialization
        pointLight = GetComponent<Light>();
    }

    void Update()
    {
        // Check if the primary button is pressed
        if (Input.GetKeyDown(primaryButtonKeyCode))
        {
            QuitGame();
        }

        // Check if the secondary button is pressed
        if (Input.GetKeyDown(secondaryButtonKeyCode))
        {
            ChangePointLightColor();
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

    void ChangePointLightColor()
    {
        // Change the color of the point light to a random color
        pointLight.color = new Color(Random.value, Random.value, Random.value);
        Debug.Log("Point light color changed");
    }
}
