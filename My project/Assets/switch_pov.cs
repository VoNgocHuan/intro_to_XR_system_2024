using UnityEngine;

public class SwitchPOV : MonoBehaviour
{
    public Transform player;
    public Transform[] viewpoints;
    private int currentViewpointIndex = 0;

    void Update()
    {
        // Check for input to switch POV
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Fire2"))  // Change "Fire1" to the button you want to use
        {
            SwitchViewpoint();
        }
    }

    void SwitchViewpoint()
    {
        // Increment the viewpoint index
        currentViewpointIndex = (currentViewpointIndex + 1) % viewpoints.Length;

        // Set the player's position and rotation based on the selected viewpoint
        player.position = viewpoints[currentViewpointIndex].position;
        player.rotation = viewpoints[currentViewpointIndex].rotation;
    }
}
