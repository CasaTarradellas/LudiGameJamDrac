using UnityEngine;

public class ButtonClicker : MonoBehaviour
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
    void OnTap(Vector2 tapPostion)
    {
        Vector2 gamePosition = cam.ScreenToWorldPoint(tapPostion);
        Collider2D col = Physics2D.OverlapPoint(gamePosition);

        if (col == null)
            return;

        AnswerButton answerButton = col.GetComponent<AnswerButton>();
        if (answerButton != null)
        {
            //I clicked a button;
            answerButton.AnswerChosen();
        }
    }
}
