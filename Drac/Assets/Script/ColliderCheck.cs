using UnityEngine;

public class ColliderCheck : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log(col.gameObject.name);
        AnswerButton answer = col.GetComponent<AnswerButton>();
        if (answer != null)
        {
            answer.AnswerChosen();
        }
    }
}
