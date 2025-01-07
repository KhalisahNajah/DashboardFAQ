using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    // This function will be called when the "Start" button is clicked
    public void StartGame()
    {
        // Load the MainScene
        SceneManager.LoadScene("MainScene");
    }

    // This function will be called when the "Quit" button is clicked
    public void QuitGame()
    {
        // If running in the Unity editor, stop playing
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #else
        // If running as a build, quit the application
        Application.Quit();
        #endif
    }
}
