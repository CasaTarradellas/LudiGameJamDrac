using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

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

    [SerializeField] GameObject GameOver;

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

    void Update()
    {
        int currentState = 0;
        switch (currentState)
        {
            case 0:
                //InitSentence();
                break;
            case 1:
                //LoopSentence();
                break;
            case 2:
                //WrongAnswer();
                break;
            case 3:
                //RightAnswer();
                break;
            case 4:
                //UpdateSentence();
                break;
            default:
                break;
        }
    }

    void SetRandomQuestion()
    {
        if (unansweredQuestions == null || unansweredQuestions.Count == 0)
        {
            Debug.Log("All questions answered!");
            GameOver.SetActive(true);
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

   
        List<string> shuffledAnswers = currentQuestion.Answers.OrderBy(x => Random.value).ToList();
        List<Transform> shuffledSpawns = spawnPoints.OrderBy(x => Random.value).ToList();

  
        currentQuestion.correctAnswerIndex = shuffledAnswers.IndexOf(currentQuestion.Answers[0]);

        StartCoroutine(SpawnButtonsCoroutine(answerCount, shuffledAnswers, shuffledSpawns));

        Debug.Log($"{currentQuestion.question} - Correct answer: {currentQuestion.Answers[0]} (spawn index {currentQuestion.correctAnswerIndex})");
    }


    IEnumerator SpawnButtonsCoroutine(int answerCount, List<string> shuffledAnswers, List<Transform> shuffledSpawns)
    {
        for (int i = 0; i < answerCount; i++)
        {
            GameObject newButton = Instantiate(answerButtonPrefab, shuffledSpawns[i]);
            RectTransform rect = newButton.GetComponent<RectTransform>();
            rect.localPosition = Vector3.zero;
            rect.localRotation = Quaternion.identity;
            rect.localScale = Vector3.one;

            AnswerButton answerBtn = newButton.GetComponent<AnswerButton>();
            answerBtn.SetAnswer(shuffledAnswers[i], i);

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
        foreach (Transform spawn in spawnPoints)
        {
            foreach (Transform child in spawn)
            {
                Button btn = child.GetComponent<Button>();
                if (btn != null)
                    btn.interactable = false;
            }
        }

    
        if (answerNumber == currentQuestion.correctAnswerIndex)
        {
            Debug.Log("Correct!");
        }
        else
        {
            Debug.Log("Wrong!");
        }

        StartCoroutine(TransitionNextQuestion());
    }
}
