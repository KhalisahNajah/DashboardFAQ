using UnityEngine;

public class BallInteraction : MonoBehaviour
{
    [SerializeField] private GameObject questionCanvas1; // The first question canvas
    [SerializeField] private GameObject questionCanvas;  // The yes/no question canvas
    [SerializeField] private GameObject instructionUI;   // "Press 'E' to interact" UI
    [SerializeField] private GameObject redCylinder;     // The red cylinder
    [SerializeField] private GameObject truePanel;       // The panel for correct answer
    [SerializeField] private GameObject falsePanel;      // The panel for incorrect answer
    [SerializeField] private float interactionRange = 3f; // Distance to interact

    private bool isPlayerNearby = false;
    private bool isPaused = false;

    private void Update()
    {
        // Check if the player is close enough to the ball
        if (isPlayerNearby && Input.GetKeyDown(KeyCode.E))
        {
            OpenQuestionCanvas1();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the player enters the interaction range
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = true;
            instructionUI.SetActive(true); // Show "Press 'E' to interact" UI
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Check if the player leaves the interaction range
        if (other.CompareTag("Player"))
        {
            isPlayerNearby = false;
            instructionUI.SetActive(false); // Hide "Press 'E' to interact" UI
        }
    }

    public void OpenQuestionCanvas1()
    {
        questionCanvas1.SetActive(true); // Show the first question canvas
        PauseGame(); // Pause the game
        instructionUI.SetActive(false); // Hide the interaction UI
    }

    public void OnNextButtonClicked()
    {
        questionCanvas1.SetActive(false); // Hide the first question canvas
        questionCanvas.SetActive(true);  // Show the yes/no question canvas
    }

    public void AnswerQuestion(string answer)
    {
        questionCanvas.SetActive(false); // Hide the question canvas

        if (answer == "Yes")
        {
            Debug.Log("Answer is Yes!");
            
            // Deactivate the red cylinder
            if (redCylinder != null)
            {
                redCylinder.SetActive(false);
            }

            // Show the true panel
            if (truePanel != null)
            {
                truePanel.SetActive(true);
            }
        }
        else if (answer == "No")
        {
            Debug.Log("Answer is No!");

            // Show the false panel
            if (falsePanel != null)
            {
                falsePanel.SetActive(true);
            }
        }

        PauseGame(); // Pause the game for True/False panel interaction
    }

    public void ClosePanel(string panel)
    {
        // Close the true or false panel
        if (panel == "True" && truePanel != null)
        {
            truePanel.SetActive(false);
        }
        else if (panel == "False" && falsePanel != null)
        {
            falsePanel.SetActive(false);
        }

        ResumeGame(); // Resume the game after the panel is closed
    }

    private void PauseGame()
    {
        isPaused = true;
        Time.timeScale = 0f; // Freeze game time
        Cursor.lockState = CursorLockMode.None; // Unlock the cursor
        Cursor.visible = true; // Make the cursor visible
    }

    private void ResumeGame()
    {
        isPaused = false;
        Time.timeScale = 1f; // Resume game time
        Cursor.lockState = CursorLockMode.Locked; // Lock the cursor
        Cursor.visible = false; // Hide the cursor
    }
}
