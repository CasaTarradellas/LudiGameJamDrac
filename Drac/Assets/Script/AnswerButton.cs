using UnityEngine;
using UnityEngine.UI;

public class AnswerButton : MonoBehaviour
{
    private GameManager gameManager;
    private Button button;

    public int answerIndex;

    void Start()
    {
        gameManager = FindFirstObjectByType<GameManager>();
        button = GetComponent<Button>();

    }

    public void SetAnswer(string answerText, int index)
    {
        answerIndex = index;

        Text textComponent = GetComponentInChildren<Text>();
        if (textComponent != null)
            textComponent.text = answerText;
    }

    void answerChosen()
    {
        gameManager.userSelectedAnswer(answerIndex);
    }
}
