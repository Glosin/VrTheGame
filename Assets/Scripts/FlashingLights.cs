using System.Collections;
using System.Linq;
using UnityEngine;

public class FlashingLights : MonoBehaviour
{
    public GameObject[] lights;
    public GameObject flashlight;
    public bool active;

    public void Flash()
    {
        active = true;
        StartCoroutine(ChangeFlash());
    }

    public IEnumerator ChangeFlash()
    {
        while (active)
        {
            yield return new WaitForSeconds(0.05f);
            int randomIndex = Random.Range(0, lights.Length);
            lights[randomIndex].GetComponent<Lamp>().Toggle();
            flashlight.GetComponent<Lamp>().Toggle();
        }

        flashlight.GetComponent<Lamp>().EnableLight();
        foreach (var light in lights)
        {
            light.GetComponent<Lamp>().EnableLight();
            light.GetComponent<AudioSource>().Stop();
        }
        
        yield return new WaitForSeconds(2f);
        int randomIndexx = Random.Range(0, lights.Length);
        lights[randomIndexx].GetComponent<Lamp>().DestroyLight();
        lights = lights.Where(obj => obj != lights[randomIndexx]).ToArray();
        
    }
}
