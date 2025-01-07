using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    public float senX = 100f;
    public float senY = 100f;
    public float smoothTime = 0.1f;  // Controls the smoothing speed

    public Transform orientation;

    private float xRotation;
    private float yRotation;
    private Vector2 currentMouseDelta;
    private Vector2 currentMouseDeltaVelocity;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;  // Hide cursor for immersion in first-person view
    }

    private void Update()
    {
        // Get raw mouse input
        float mouseX = Input.GetAxisRaw("Mouse X") * senX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * senY;

        // Smooth the mouse movement
        currentMouseDelta = Vector2.SmoothDamp(currentMouseDelta, new Vector2(mouseX, mouseY), ref currentMouseDeltaVelocity, smoothTime);

        // Update rotations with smoothed input
        yRotation += currentMouseDelta.x * Time.deltaTime;
        xRotation -= currentMouseDelta.y * Time.deltaTime;

        // Clamp the vertical rotation to avoid flipping
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        // Apply rotation to the camera and orientation object
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);
    }
}
