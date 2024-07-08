using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorChangeOnClick : MonoBehaviour
{
    public Texture2D defaultCursor;
    public Texture2D clickCursor;
    public Vector2 cursorHotspot = Vector2.zero;

    // Start is called before the first frame update
    void Start()
    {
        // Oyun başladığında default cursor ayarla
        Cursor.SetCursor(defaultCursor, cursorHotspot, CursorMode.Auto);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Mouse tıklama başladığında click cursor ayarla
            Cursor.SetCursor(clickCursor, cursorHotspot, CursorMode.Auto);
        }

        if (Input.GetMouseButtonUp(0))
        {
            // Mouse tıklama bittiğinde default cursor geri ayarla
            Cursor.SetCursor(defaultCursor, cursorHotspot, CursorMode.Auto);
        }
    }
}
