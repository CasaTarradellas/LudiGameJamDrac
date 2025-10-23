using UnityEditor.TerrainTools;
using UnityEngine;

public class FinishState : BaseState
{
    private float currentTime;
    [SerializeField] private const float timeBetweenQuestion = 5;
    public override void StartState()
    {
    }

    public override bool UpdateState()
    {
        return false;
    }
    public override int Finish()
    {
        return 0;
    }
    void TransitionNextQuestion()
    {
        //unansweredQuestions.Remove(currentQuestion);
        //ClearOldAnswers();
        //SFX donde me cargo los botones.
        //SetRandomQuestion();
    }
    public void ClearOldAnswers()
    {
        //for (int i = activeButtons.Count - 1; i >= 0; i--)
        //{
        //    Destroy(activeButtons[i].gameObject);
        //}
    }
}
