using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AnswerButton : MonoBehaviour
{
    private int answerIndex;
    private GameManager gameManager;

    [SerializeField] private TextMeshProUGUI answerText;

    void Awake()
    {
        if (answerText == null)
            answerText = GetComponentInChildren<TextMeshProUGUI>();

        gameManager = FindFirstObjectByType<GameManager>();

        if (gameManager == null)
            Debug.LogError("GameManager not found in the scene!");
    }

    public void SetAnswer(string answer, int index)
    {
        answerIndex = index;

        if (answerText != null)
            answerText.text = answer;
        else
            Debug.LogWarning("TextMeshProUGUI component not found on AnswerButton prefab!");
    }
    public void ClearOldAnswers()
    {
        AnswerButton[] allButtons = FindObjectsByType<AnswerButton>(
            FindObjectsInactive.Exclude,
            sortMode: FindObjectsSortMode.None
        );

        foreach (AnswerButton btn in allButtons)
        {
            Destroy(btn.gameObject);
        }
    }
    public void anwserChosen()
    {
        ClearOldAnswers();

        gameManager.userSelectedAnswer(answerIndex);
    }
}
