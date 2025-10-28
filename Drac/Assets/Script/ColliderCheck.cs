using System.Collections;
using UnityEngine;

public class ColliderCheck : MonoBehaviour
{
    public ParticleSystem particles;
    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log(col.gameObject.name);
        AnswerButton answer = this.GetComponent<AnswerButton>();
        if (answer != null)
        {
            StartCoroutine(OnCollide(answer));
        }
    }
    IEnumerator OnCollide(AnswerButton answer)
    {
        this.GetComponent<Collider2D>().enabled = false;
        this.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        this.GetComponent<Animator>().SetTrigger("Collided");
        particles?.Play();
        yield return new WaitForSeconds(1.0f);
        answer.AnswerChosen();
    }
}
