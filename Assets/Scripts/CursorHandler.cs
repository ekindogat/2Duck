using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorHandler : MonoBehaviour
{
    public Texture2D onHoverCursor;
    public Texture2D clickCursor;
    public Texture2D defaultCursor;
    void OnMouseEnter(){
         Cursor.SetCursor(onHoverCursor, Vector2.zero, CursorMode.Auto);
    }
    void OnMouseExit(){
        Cursor.SetCursor(defaultCursor, Vector2.zero, CursorMode.Auto);
    }
     void OnMouseDown()
    {
        Cursor.SetCursor(clickCursor, Vector2.zero, CursorMode.Auto);
    }

    void OnMouseUp(){
        Cursor.SetCursor(onHoverCursor, Vector2.zero, CursorMode.Auto);
    }

}
