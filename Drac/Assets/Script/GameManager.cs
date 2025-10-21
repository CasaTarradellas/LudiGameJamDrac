using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class GameManager : MonoBehaviour
{
    public Questions[] questionArray;
    private static List<Questions> unanswereQuestions;
    private Questions currentQuestion;

    [SerializeField] private Text questionText;

    void Start()
    {
        if (unanswereQuestions == null || unanswereQuestions.Count == 0)
        {
            unanswereQuestions = questionArray.ToList<Questions>();
        }

        SetRandomQuestion();
        Debug.Log(currentQuestion.question + " is " + currentQuestion.correctAnswer);
    }

    void SetRandomQuestion()
    {
        int randomQuestionIndex = Random.Range(0, unanswereQuestions.Count);
        currentQuestion = unanswereQuestions[randomQuestionIndex];

        questionText.text = currentQuestion.question; 

        unanswereQuestions.RemoveAt(randomQuestionIndex);
    }

    public void userSelectedAnswer(int answerNumber)
    {
        if (currentQuestion.correctAnswer == answerNumber)
        {
            Debug.Log("Correct");
        }
        else
        {
            Debug.Log("Wrong");
        }
    }
}
