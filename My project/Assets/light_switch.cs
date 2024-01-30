using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class VRInteractiveLight : XRGrabInteractable
{
    private Light lightComponent;
    private bool isLightOn = false;

    protected override void OnEnable()
    {
        base.OnEnable();
        lightComponent = GetComponent<Light>();
        if (lightComponent == null)
        {
            Debug.LogError("No Light component found on the GameObject.");
            enabled = false;
            return;
        }
        onSelectEntered.AddListener(ToggleLight);
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        onSelectEntered.RemoveListener(ToggleLight);
    }

    private void ToggleLight(XRBaseInteractor interactor)
    {
        isLightOn = !isLightOn;
        lightComponent.enabled = isLightOn;
    }
}
