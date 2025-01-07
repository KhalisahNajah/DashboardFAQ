using UnityEngine;

public class BallInteraction2 : MonoBehaviour
{
    [SerializeField] private GameObject questionCanvas1_2; // The first question canvas
    [SerializeField] private GameObject questionCanvas2;  // The yes/no question canvas
    [SerializeField] private GameObject instructionUI2;   // "Press 'E' to interact" UI
    [SerializeField] private GameObject redCylinder2;     // The red cylinder
    [SerializeField] private GameObject truePanel2;       // The panel for correct answer
    [SerializeField] private GameObject falsePanel2;      // The panel for incorrect answer
    [SerializeField] private float interactionRange2 = 3f; // Distance to interact

    private bool isPlayerNearby2 = false;
    private bool isPaused2 = false;

    private void Update2()
    {
        // Check if the player is close enough to the ball
        if (isPlayerNearby2 && Input.GetKeyDown(KeyCode.E))
        {
            OpenQuestionCanvas1_2();
        }
    }

    private void OnTriggerEnter2(Collider other)
    {
        // Check if the player enters the interaction range
        if (other.CompareTag("Player"))
        {
            isPlayerNearby2 = true;
            instructionUI2.SetActive(true); // Show "Press 'E' to interact" UI
        }
    }

    private void OnTriggerExit2(Collider other)
    {
        // Check if the player leaves the interaction range
        if (other.CompareTag("Player"))
        {
            isPlayerNearby2 = false;
            instructionUI2.SetActive(false); // Hide "Press 'E' to interact" UI
        }
    }

    public void OpenQuestionCanvas1_2()
    {
        questionCanvas1_2.SetActive(true); // Show the first question canvas
        PauseGame2(); // Pause the game
        instructionUI2.SetActive(false); // Hide the interaction UI
    }

    public void OnNextButtonClicked2()
    {
        questionCanvas1_2.SetActive(false); // Hide the first question canvas
        questionCanvas2.SetActive(true);  // Show the yes/no question canvas
    }

    public void AnswerQuestion2(string answer)
    {
        questionCanvas2.SetActive(false); // Hide the question canvas

        if (answer == "Yes")
        {
            Debug.Log("Answer is Yes!");
            
            // Deactivate the red cylinder
            if (redCylinder2 != null)
            {
                redCylinder2.SetActive(false);
            }

            // Show the true panel
            if (truePanel2 != null)
            {
                truePanel2.SetActive(true);
            }
        }
        else if (answer == "No")
        {
            Debug.Log("Answer is No!");

            // Show the false panel
            if (falsePanel2 != null)
            {
                falsePanel2.SetActive(true);
            }
        }

        PauseGame2(); // Pause the game for True/False panel interaction
    }

    public void ClosePanel2(string panel)
    {
        // Close the true or false panel
        if (panel == "True" && truePanel2 != null)
        {
            truePanel2.SetActive(false);
        }
        else if (panel == "False" && falsePanel2 != null)
        {
            falsePanel2.SetActive(false);
        }

        ResumeGame2(); // Resume the game after the panel is closed
    }

    private void PauseGame2()
    {
        isPaused2 = true;
        Time.timeScale = 0f; // Freeze game time
        Cursor.lockState = CursorLockMode.None; // Unlock the cursor
        Cursor.visible = true; // Make the cursor visible
    }

    private void ResumeGame2()
    {
        isPaused2 = false;
        Time.timeScale = 1f; // Resume game time
        Cursor.lockState = CursorLockMode.Locked; // Lock the cursor
        Cursor.visible = false; // Hide the cursor
    }
}
