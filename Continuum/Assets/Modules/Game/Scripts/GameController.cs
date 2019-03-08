using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public Texture2D MouseCursor;

    private void Awake()
    {
        Cursor.SetCursor(MouseCursor, Vector2.zero, CursorMode.ForceSoftware);
    }
}
