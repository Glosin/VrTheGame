using System.Collections;
using System.Linq;
using UnityEngine;

public class FlashingLights : MonoBehaviour
{
    public GameObject[] lights;
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
        }

        foreach (var light in lights)
        {
            light.GetComponent<Lamp>().EnableLight();
            light.GetComponent<AudioSource>().Stop();
        }
        
        int randomIndexx = Random.Range(0, lights.Length);
        lights[randomIndexx].GetComponent<Lamp>().DisableLight();
        lights = lights.Where(obj => obj != lights[randomIndexx]).ToArray();
        
    }
}
