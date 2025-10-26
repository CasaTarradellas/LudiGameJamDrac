using UnityEditor.TerrainTools;
using UnityEngine;

public class FinishState : BaseState
{
    private GameplayState gameplayState;

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
        GameplayState.unansweredQuestions.Remove(gameplayState.currentQuestion);
        ClearOldAnswers();
        //SFX donde me cargo los botones.
        Finish();
    }
    public void ClearOldAnswers()
    {
        for (int i = gameplayState.activeButtons.Count - 1; i >= 0; i--)
        {
            Destroy(gameplayState.activeButtons[i].gameObject);
        }
    }
}
