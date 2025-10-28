using UnityEngine;

public class ButtonDetecter : MonoBehaviour
{
    [SerializeField] private Camera cam;

    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        //PC control
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            OnTap(Input.mousePosition);
        }
        else if (Input.touchCount > 0)
        {
            OnTap(Input.touches[0].position);
        }
    }
    void OnTap(Vector2 screenPosition)
    {
        if (cam == null) { Debug.LogWarning("No hay c�mara asignada."); return; }

        Vector3 wp = cam.ScreenToWorldPoint(screenPosition);
        Vector2 p = new Vector2(wp.x, wp.y);

        RaycastHit2D hit = Physics2D.Raycast(p, Vector2.zero);

        if (hit.collider == null)
        {
            Debug.Log("No has clicado nada.");
            return;
        }

        Debug.Log("Has clicado: " + hit.collider.name);

        var answerButton = hit.collider.GetComponent<AnswerButton>();
        if (answerButton != null)
        {
            answerButton.AnswerChosen();
        }
        else
        {
            answerButton = hit.collider.GetComponentInParent<AnswerButton>();
            if (answerButton != null) answerButton.AnswerChosen();
        }
    }
}
