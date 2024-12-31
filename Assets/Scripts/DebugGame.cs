using UnityEngine;
using UnityEngine.XR;

public class DebugGame : MonoBehaviour
{
    void Update()
    {
        InputDevice rightHandDevice = InputDevices.GetDeviceAtXRNode(XRNode.RightHand);
        // Check if the secondary button is pressed
        if (rightHandDevice.TryGetFeatureValue(CommonUsages.primaryButton, out bool isPressed) && isPressed)
        {
            Debug.Log("Secondary Button Pressed!");
        }
    }
}
