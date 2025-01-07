using UnityEngine;

public class AnswerHandler : MonoBehaviour
{
    // Reference to the TriggerCanvas to call AnswerQuestion method
    public TriggerCanvas triggerCanvas;

    // Called when the player answers "Yes"
    public void HandleYes()
    {
        Debug.Log("Yes was clicked");
        // Pass the correct answer (true) to the TriggerCanvas
        if (triggerCanvas != null)
        {
            triggerCanvas.AnswerQuestion(true);
        }
    }

    // Called when the player answers "No"
    public void HandleNo()
    {
        Debug.Log("No was clicked");
        // Pass the incorrect answer (false) to the TriggerCanvas
        if (triggerCanvas != null)
        {
            triggerCanvas.AnswerQuestion(false);
        }
    }
}
