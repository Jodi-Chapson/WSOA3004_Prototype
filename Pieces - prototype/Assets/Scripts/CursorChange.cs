using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorChange : MonoBehaviour
{
    public Texture2D cursortexture;
    public CursorMode mode = CursorMode.Auto;
    void Start()
    {
        Cursor.SetCursor(cursortexture, Vector2.zero, mode);
    }
}

    
