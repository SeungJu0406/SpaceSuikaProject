using UnityEngine;

public class CursorController : MonoBehaviour
{

    private void Update()
    {
        MoveCursor();
    }

    void MoveCursor()
    {
        transform.position = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }
}
