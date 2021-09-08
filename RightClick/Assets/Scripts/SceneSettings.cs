using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneSettings : MonoBehaviour
{
    public Texture2D arrow;
    private void Start()
    {
        ResetCursor();
    }
    public void ResetCursor()
    {
        Cursor.SetCursor(arrow, Vector2.zero, CursorMode.ForceSoftware);
    }
    public void SetCursorTo(Texture2D cursor)
    {
        Cursor.SetCursor(cursor, Vector2.zero, CursorMode.ForceSoftware);
    }

}
