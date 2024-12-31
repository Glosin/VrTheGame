using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class Lamp : MonoBehaviour
{
    public GameObject lampObject;
    public Material defaultMaterial;
    public Material lampMaterial;
    public Light light;
    public AudioSource audioSource;
    public AudioClip lampSound;
    public AudioClip lampSound2;
    
    private bool _active = true;

    public void DisableLight()
    {
        light.enabled = false;
        if (lampObject != null)
            lampObject.GetComponent<Renderer>().material = defaultMaterial;
    }
    public void DestroyLight()
    {
        audioSource.volume = 0.8f;
        audioSource.maxDistance = 100f;
        audioSource.PlayOneShot(lampSound2);
        audioSource.maxDistance = 3f;
        audioSource.volume = 0.5f;
        DisableLight();
        FindAnyObjectByType<FlashingLights>().DropFromLightsArray(gameObject.GetComponent<Lamp>());
    }
    
    public void EnableLight()
    {
        light.enabled = true;
        if (lampObject != null)
            lampObject.GetComponent<Renderer>().material = lampMaterial;
    }

    public void Toggle()
    {
        if (audioSource!= null && !audioSource.isPlaying)
            audioSource.PlayOneShot(lampSound);
        
        if (_active)
            DisableLight();
        else
            EnableLight();
        
        _active = !_active;
    }
}
