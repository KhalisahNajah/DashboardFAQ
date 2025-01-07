using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenu; // Assign this in the Inspector
    private bool isPaused = false;

    public void Pause()
    {
        Debug.Log("Pause button clicked!");
        pauseMenu.SetActive(true);
        Time.timeScale = 0f; // Freeze the game
        Cursor.lockState = CursorLockMode.None; // Unlock the cursor
        Cursor.visible = true; // Make the cursor visible
        isPaused = true;
    }

    public void Resume()
    {
        Debug.Log("Resume button clicked!");
        pauseMenu.SetActive(false);
        Time.timeScale = 1f; // Resume the game
        Cursor.lockState = CursorLockMode.Locked; // Lock the cursor
        Cursor.visible = false; // Hide the cursor
        isPaused = false;
    }

    public void MainMenu()
    {
        Debug.Log("Main menu button clicked! Loading MainMenuScene.");
        Time.timeScale = 1f; // Resume the game before switching scenes
        SceneManager.LoadScene("MainMenuScene");
    }

    // Optional method to toggle between Pause and Resume
    public void TogglePause()
    {
        if (isPaused)
        {
            Resume();
        }
        else
        {
            Pause();
        }
    }
}
