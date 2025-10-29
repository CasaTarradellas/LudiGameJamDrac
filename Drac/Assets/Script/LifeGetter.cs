using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class LifeGetter : MonoBehaviour
{
    [SerializeField] private ScoreMaster scoreMaster;

    [SerializeField] private Image heart1;
    [SerializeField] private Image heart2;
    [SerializeField] private Image heart3;

    [SerializeField] private Animator dracAnimator;

    private static readonly int DracMalHash = Animator.StringToHash("dracMal");

    private int lastLife = -1;
    private bool hurtRoutineRunning = false;

    void Update()
    {
        if (scoreMaster == null) return;

        int life = scoreMaster.life;
        if (life == lastLife) return;

        lastLife = life;
        UpdateHearts(life);
        UpdateAnimatorOnLifeChange(life);
    }

    void UpdateHearts(int life)
    {
        heart1.enabled = life >= 1;
        heart2.enabled = life >= 2;
        heart3.enabled = life >= 3;
    }

    void UpdateAnimatorOnLifeChange(int life)
    {
        if (dracAnimator == null) return;

        if (life == 2 || life == 1)
        {
            if (!hurtRoutineRunning) StartCoroutine(DracHurt());
        }

    }

    IEnumerator DracHurt()
    {
        hurtRoutineRunning = true;
        dracAnimator.SetBool(DracMalHash, true);

        yield return new WaitForSeconds(1.1f);

        dracAnimator.SetBool(DracMalHash, false);

        hurtRoutineRunning = false;
    }
}
