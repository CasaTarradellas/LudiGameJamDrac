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
        Vector3 pos = cam.ScreenToWorldPoint(Input.mousePosition);
        float screnWidthToWorld = cam.ScreenToWorldPoint(new Vector3(Screen.width,0,0)).x - 0.5f;
        
        pos.x = Mathf.Clamp(pos.x, -screnWidthToWorld, screnWidthToWorld);
        pos.y = transform.position.y;
        

        return pos;
    }
}
