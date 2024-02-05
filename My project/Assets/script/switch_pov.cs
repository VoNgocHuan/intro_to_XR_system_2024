using UnityEngine;

public class Oculus_switch_pov_Script : MonoBehaviour
{
    private KeyCode primaryButtonKeyCode = KeyCode.JoystickButton0; // A button on Oculus Touch
    private KeyCode gripButtonKeyCode = KeyCode.JoystickButton14; // Grip button on Oculus Touch

    public Transform player;
    public Transform teleportTarget;

    void Update()
    {
        // Check if the primary button is pressed
        if (Input.GetKeyDown(primaryButtonKeyCode))
        {
            QuitGame();
        }

        // Check if the grip button is pressed
        if (Input.GetKeyDown(gripButtonKeyCode))
        {
            TeleportPlayer();
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

    void TeleportPlayer()
    {
        // Teleport the player to the teleport target position
        if (player != null && teleportTarget != null)
        {
            player.position = teleportTarget.position;
            Debug.Log("Player teleported to the target position");
        }
        else
        {
            Debug.LogError("Player or teleport target not assigned in the inspector.");
        }
    }
}
