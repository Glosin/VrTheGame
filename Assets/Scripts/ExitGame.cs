using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitGame : MonoBehaviour
{
    public Door door;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && door.opening)
        { 
            SceneManager.LoadScene(1);
        }
    }

    public void QuitGame()
    {
        #if UNITY_EDITOR
            EditorApplication.isPlaying = false; // Stop play mode in Editor
        #else
            Application.Quit(); // Quit the application
        #endif
    }
}
