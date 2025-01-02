using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem.XR;
using UnityEngine.SceneManagement;

public class JumpScare : MonoBehaviour
{
    public Camera mainCamera;
    public Transform target;
    public GameObject zombie;
    
    public void JumpScareStart()
    {
        mainCamera.GetComponent<TrackedPoseDriver>().enabled = false;
        mainCamera.GetComponent<AudioSource>().Play();
        FindAnyObjectByType<CharacterController>().enabled = false;
        Instantiate(zombie, target.transform.position, target.transform.rotation);
        StartCoroutine(NewSceneMode());
    }

    IEnumerator NewSceneMode()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(2);
    }
}
