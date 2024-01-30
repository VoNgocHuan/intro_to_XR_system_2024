using UnityEngine;
using UnityEngine.XR;

public class VRQuitScript : MonoBehaviour
{
    [SerializeField]
    private string quitButton = "Fire1"; // Set the default input button

    // Update is called once per frame
    void Update()
    {
        // Check if the specified button is pressed
        if (Input.GetButtonDown(quitButton))
        {
            QuitApplication();
        }
    }

    void QuitApplication()
    {
        // Check if the application is running in VR mode
        if (XRSettings.isDeviceActive)
        {
            // Quit VR headset
            XRSettings.enabled = false;
        }

        // Quit the application
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
