using UnityEngine;

public class MovementBoundary : MonoBehaviour
{
    [SerializeField] private Canvas canvas;
    private Vector2 movementBounds;

    private float h;
    private float w;

    void Start()
    {
        float distance = Mathf.Abs(Camera.main.transform.position.z - transform.position.z);

        h = canvas.GetComponent<RectTransform>().rect.height;
        w = canvas.GetComponent<RectTransform>().rect.width;
        movementBounds = Camera.main.ScreenToWorldPoint(new Vector3(w, h, distance));
    }

    void Update()
    {
        Vector2 position = transform.position;
        position.x = Mathf.Clamp(position.x, -movementBounds.x, movementBounds.x);
        position.y = Mathf.Clamp(position.y, -movementBounds.y, movementBounds.y);
        transform.position = position;
    }
}
