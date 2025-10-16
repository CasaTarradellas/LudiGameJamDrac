using UnityEngine;
using UnityEngine.UI;

public class AnswerButton : MonoBehaviour
{
    private GameManager gameManager;
    public int answerIndex;

    void Start()
    {
        gameManager = FindFirstObjectByType<GameManager>();
    }

    public void SetAnswer(string answerText, int index)
    {
        answerIndex = index;

        Text textComponent = GetComponentInChildren<Text>();
        if (textComponent != null)
            textComponent.text = answerText;
    }

    public void answerChosen()
    {
        gameManager.userSelectedAnswer(answerIndex);
    }
}
