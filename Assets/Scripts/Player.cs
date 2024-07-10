using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Texture2D defaultCursor;
    public Texture2D clickCursor;
    public Vector2 cursorHotspot = Vector2.zero;
    public GameObject targetGameObject; // Assign your target GameObject in the Inspector

    void Start()
    {
        // Set default cursor at the start of the game
        Cursor.SetCursor(defaultCursor, cursorHotspot, CursorMode.Auto);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Perform a raycast to check if the mouse is over the target GameObject
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject == targetGameObject)
                {
                    // Keep the click cursor if the mouse is over the target GameObject
                    return;
                }
            }
            // Set click cursor when mouse button is pressed
            Cursor.SetCursor(clickCursor, cursorHotspot, CursorMode.Auto);
        }

        if (Input.GetMouseButtonUp(0))
        {
            // Perform a raycast to check if the mouse is over the target GameObject
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject == targetGameObject)
                {
                    // Keep the click cursor if the mouse is over the target GameObject
                    return;
                }
            }

            // Set default cursor if the mouse is not over the target GameObject
            Cursor.SetCursor(defaultCursor, cursorHotspot, CursorMode.Auto);
        }
    }
}