using TMPro;
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
        TextMeshProUGUI tmp = GetComponentInChildren<TextMeshProUGUI>();
        if (tmp != null)
            tmp.text = answerText;
        else
            Debug.LogWarning("TextMeshProUGUI component not found in button prefab!");
    }

    public void answerChosen()
    {
        gameManager.userSelectedAnswer(answerIndex);
    }
}
