using UnityEngine;

public class FinishState : BaseState
{
    [SerializeField] private GameplayState gameplayState;

    public override void StartState() { }

    public override bool UpdateState() { return false; }
    public override int Finish() { return 0; }

    public void TransitionNextQuestion()
    {
        if (gameplayState == null || gameplayState.currentQuestion == null) return;

        GameplayState.unansweredQuestions.Remove(gameplayState.currentQuestion);
        ClearOldAnswers();
        Finish();
    }

    public void ClearOldAnswers()
    {
        if (gameplayState == null) return;
        for (int i = gameplayState.activeButtons.Count - 1; i >= 0; i--)
            Object.Destroy(gameplayState.activeButtons[i].gameObject);
        gameplayState.activeButtons.Clear();
    }
}
