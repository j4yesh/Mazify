using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class zoom : MonoBehaviour
{
     public Transform objectToZoom; // Drag and drop the 2D object you want to zoom in on here
    public float zoomSpeed = 1.0f;
    public float minZoom = 1.0f;
    public float maxZoom = 10.0f;
    public float panSpeed = 2.0f;

    private Vector3 initialScale;
    private Vector3 lastMousePosition;
    private bool isDragging = false;

    private void Start()
    {
        initialScale = objectToZoom.localScale;
    }

    private void Update()
    {
        // Check for mouse button down to start dragging
        if (Input.GetMouseButtonDown(0))
        {
            isDragging = true;
            lastMousePosition = Input.mousePosition;
        }

        // Check for mouse button up to stop dragging
        if (Input.GetMouseButtonUp(0))
        {
            isDragging = false;
        }

        // Zoom in or out based on mouse wheel input
        float zoomInput = Input.GetAxis("Mouse ScrollWheel");
        float newZoom = Mathf.Clamp(objectToZoom.localScale.x - zoomInput * zoomSpeed, minZoom, maxZoom);
        objectToZoom.localScale = new Vector3(newZoom, newZoom, 1);

        // If dragging, pan the object
        if (isDragging)
        {
            Vector3 deltaMousePosition = Input.mousePosition - lastMousePosition;
            Vector3 moveVector = new Vector3(deltaMousePosition.x, deltaMousePosition.y, 0) * panSpeed * Time.deltaTime;
            objectToZoom.position += moveVector;

            lastMousePosition = Input.mousePosition;
        }
    }
}
