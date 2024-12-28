using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class Lamp : MonoBehaviour
{
    public GameObject lampObject;
    public Material defaultMaterial;
    public Material lamptMaterial;
    public Light light;

    public void DisableLight()
    {
        lampObject.GetComponent<Renderer>().material = defaultMaterial;
        light.enabled = false;
    }
}
