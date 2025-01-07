using UnityEngine;

public class TriggerCanvas2 : MonoBehaviour
{
    [SerializeField]
    private GameObject Quiz1; // The quiz canvas
    [SerializeField]
    private GameObject False1; // The red cylinder (blocking)
    [SerializeField]
    private GameObject True1; // The green cylinder (passable)

    private bool hasInteracted = false; // Flag to track interaction

    private void Start2()
    {
        // Ensure the correct setup in case something is wrong
        if (False1 != null)
        {
            False1.SetActive(true); // Red cylinder is visible initially
        }
        if (True1 != null)
        {
            True1.SetActive(false); // Green cylinder is hidden initially
        }
    }

    private void OnTriggerEnter2(Collider other)
    {
        // Show the canvas when the player enters the trigger zone, but only if not already interacted
        if (other.CompareTag("Player") && !hasInteracted)
        {
            if (Quiz1 != null)
            {
                Quiz1.SetActive(true); // Show the canvas
            }
        }
    }

    public void AnswerQuestion2(bool isCorrect)
    {
        if (Quiz1 != null)
        {
            Quiz1.SetActive(false); // Close the canvas when the player answers
        }

        // Prevent the canvas from being shown again
        hasInteracted = true;

        // Handle cylinder visibility based on the answer
        if (isCorrect)
        {
            if (False1 != null)
            {
                False1.SetActive(false); // Deactivate the red cylinder
            }
            if (True1 != null)
            {
                True1.SetActive(true); // Activate the green cylinder
            }
        }
        else
        {
            Debug.Log("Incorrect answer. Red cylinder remains active.");
        }
    }
}
