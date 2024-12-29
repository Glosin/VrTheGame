using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class Lamp : MonoBehaviour
{
    public GameObject lampObject;
    public Material defaultMaterial;
    public Material lamptMaterial;
    public Light light;
    
    private bool _active = true;

    public void DisableLight()
    {
        lampObject.GetComponent<Renderer>().material = defaultMaterial;
        light.enabled = false;
    }
    
    public void EnableLight()
    {
        lampObject.GetComponent<Renderer>().material = lamptMaterial;
        light.enabled = true;
    }

    public void Toggle()
    {
        if (_active)
            DisableLight();
        else
            EnableLight();
        
        _active = !_active;
    }
}
