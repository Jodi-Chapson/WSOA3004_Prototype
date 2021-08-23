using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorChange : MonoBehaviour
{
    public Texture2D cursortexture;
    public CursorMode mode = CursorMode.Auto;

    public bool toChange;
    void Start()
    {
        if (!toChange)
        {
            Cursor.SetCursor(cursortexture, Vector2.zero, mode);
        }
    }

    public void ChangeTexture()
    {
        Cursor.SetCursor(cursortexture, Vector2.zero, mode);
    }
}

    
