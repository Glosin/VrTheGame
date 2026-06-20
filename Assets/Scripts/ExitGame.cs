using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class ExitGame : MonoBehaviour
{
    public Door door;
    public ScoreController scoreController;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && door.opening)
        {
            Debug.Log(scoreController.score);
            PlayerPrefs.SetInt("score", scoreController.score);
            PlayerPrefs.Save();
            LoadScene(2);
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

    public void LoadScene(int index)
    {
        SceneManager.LoadSceneAsync(index);
    }
}
