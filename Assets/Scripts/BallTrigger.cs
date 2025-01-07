using UnityEngine;
using UnityEngine.UI;

public class BallTrigger : MonoBehaviour
{
    public GameObject Quiz1; // Reference to the Canvas GameObject named "question1"
    public Button yes;  // Reference to the "Yes" button on the Canvas
    public Button no;   // Reference to the "No" button on the Canvas

    private bool isTriggered = false; // Flag to check if the ball has already been answered correctly

   void Start()
{
    // Initially hide the canvas
    Quiz1.SetActive(false);

    // Assign button listeners
    if (yes != null)
    {
        yes.onClick.AddListener(HandleYes);
        Debug.Log("Yes button listener added.");
    }
    else
    {
        Debug.LogError("Yes button is not assigned.");
    }

    if (no != null)
    {
        no.onClick.AddListener(HandleNo);
        Debug.Log("No button listener added.");
    }
    else
    {
        Debug.LogError("No button is not assigned.");
    }
}


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isTriggered)
        {
            // Show the canvas when the player collides with the ball
            Quiz1.SetActive(true);
        }
    }

    public void HandleYes()
    {
        Debug.Log("Yes was clicked");
        // Close the canvas and mark the ball as triggered
        if (Quiz1 != null)
        {
            Quiz1.SetActive(false);
        }
        isTriggered = true;
    }

    public void HandleNo()
    {
        Debug.Log("No was clicked");
        // Close the canvas without marking the ball as triggered
        if (Quiz1 != null)
        {
            Quiz1.SetActive(false);
        }
    }
}
