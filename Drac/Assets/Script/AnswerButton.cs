using UnityEngine;
using TMPro;

public class AnswerButton : MonoBehaviour
{
    private int answerIndex;
    [HideInInspector] public GameManager gameManager;

    [SerializeField] private TextMeshProUGUI answerText;

    public void Initialize(GameManager manager, string answer, int index)
    {
        gameManager = manager;
        answerIndex = index;
        answerText.text = answer;
    }

    public void AnswerChosen()
    {
        gameManager.userSelectedAnswer(answerIndex);
    }
}
