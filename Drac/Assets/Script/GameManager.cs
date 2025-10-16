using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class GameManager : MonoBehaviour
{
    public Questions[] questionArray;
    private static List<Questions> unansweredQuestions;
    private Questions currentQuestion;

    [SerializeField] private GameObject answerButtonPrefab;
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private float buttonSpawnDelay = 2f;

    [SerializeField] private Text questionText;
    [SerializeField] private float timeBetweenQuestion = 5;

    void Awake()
    {
        if (unansweredQuestions == null || unansweredQuestions.Count == 0)
        {
            unansweredQuestions = questionArray.ToList();
        }
    }
    void Start()
    {
        SetRandomQuestion();
    }

    void SetRandomQuestion()
    {
        if (unansweredQuestions == null || unansweredQuestions.Count == 0)
        {
            Debug.Log("All questions answered!");
            Application.Quit();
        }

        int randomQuestionIndex = Random.Range(0, unansweredQuestions.Count);
        currentQuestion = unansweredQuestions[randomQuestionIndex];

        questionText.text = currentQuestion.question;

        SpawnAnswers();
    }
    void SpawnAnswers()
    {
        foreach (Transform spawn in spawnPoints)
        {
            foreach (Transform child in spawn)
                Destroy(child.gameObject);
        }

        int answerCount = currentQuestion.Answers.Length;
        if (answerCount > spawnPoints.Length)
        {
            Debug.LogWarning("Not enough spawn points! Reducing button count to available spawn points.");
            answerCount = spawnPoints.Length;
        }

        List<Transform> shuffledSpawns = spawnPoints.OrderBy(x => Random.value).ToList();

        StartCoroutine(SpawnButtonsCoroutine(answerCount, shuffledSpawns));

        Debug.Log(currentQuestion.question + " is " + currentQuestion.correctAnswer);
    }


       IEnumerator SpawnButtonsCoroutine(int answerCount, List<Transform> shuffledSpawns)
    {
       for (int i = 0; i < answerCount; i++)
       {
            int answerIndex = i;

            GameObject newButton = Instantiate(answerButtonPrefab, shuffledSpawns[i]);

            RectTransform rect = newButton.GetComponent<RectTransform>();
            rect.localPosition = Vector3.zero;
            rect.localRotation = Quaternion.identity;
            rect.localScale = Vector3.one;

            AnswerButton answerBtn = newButton.GetComponent<AnswerButton>();
            answerBtn.SetAnswer(currentQuestion.Answers[answerIndex], answerIndex);

            yield return new WaitForSeconds(buttonSpawnDelay);
       }
    }

    IEnumerator TransitionNextQuestion()
    {
        unansweredQuestions.Remove(currentQuestion);
        yield return new WaitForSeconds(timeBetweenQuestion);

        SetRandomQuestion();
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

        StartCoroutine(TransitionNextQuestion());
    }
}
