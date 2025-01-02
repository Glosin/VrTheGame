using System;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class CodeCheck : MonoBehaviour
{
    public XRSocketInteractorTag[] XRSocketInteractor;
    public GameObject[] codeCheck;
    public Door door;

    public void Check()
    {
        for (int i = 0; i < XRSocketInteractor.Length; i++)
        {
            if (!XRSocketInteractor[i].IsSelecting(codeCheck[i].GetComponent<XRGrabInteractable>()))
                return;
        }
        door.opening = true;
    }
}
