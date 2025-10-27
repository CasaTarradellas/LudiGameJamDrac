using UnityEngine;
public class DragonMove : MonoBehaviour
{
    private Camera cam;
    void Start()
    {
        cam = Camera.main;
        Cursor.visible = false;
    }

    void Update()
    {
        FollowMouse();
    }
    private void FollowMouse()
    {
        transform.position = GetWorldPos();
    }

    private Vector2 GetWorldPos()
    {
        return cam.ScreenToWorldPoint(Input.mousePosition);
    }
}
