using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;
using UnityEngine;

public class XRSocketInteractorTag : XRSocketInteractor
{
    public string targetTag;

    public override bool CanSelect(IXRSelectInteractable interactable)
    {
        // Check if the interactable object has the target tag
        if (interactable is MonoBehaviour interactableComponent)
        {
            if (interactableComponent.gameObject.CompareTag(targetTag))
            {
                return base.CanSelect(interactable); // Allow selection if the tag matches
            }
        }

        // Reject selection if the tag doesn't match
        return false;
    }
}
