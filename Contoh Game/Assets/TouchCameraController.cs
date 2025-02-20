using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchCameraController : MonoBehaviour
{
    private Vector2 startTouchPosition, currentTouchPosition;
    private bool isDragging;

    public float rotationSpeed = 0.2f; // Sesuaikan kecepatan rotasi

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
            {
                isDragging = true;
                startTouchPosition = touch.position;
            }
            else if (touch.phase == TouchPhase.Moved && isDragging)
            {
                currentTouchPosition = touch.position;
                Vector2 delta = currentTouchPosition - startTouchPosition;

                // Menggerakkan kamera berdasarkan gerakan jari
                transform.Rotate(0, -delta.x * rotationSpeed, 0);
                startTouchPosition = currentTouchPosition;
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                isDragging = false;
            }
        }
    }
}
