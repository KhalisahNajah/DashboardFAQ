using UnityEngine;

public class CloseCanvasButton : MonoBehaviour
{
    public Canvas canvasToClose; // Assign the canvas in the Inspector

    // This function will be called when the button is clicked
    public void CloseCanvas()
    {
        canvasToClose.gameObject.SetActive(false); // Hide the canvas
    }
}
