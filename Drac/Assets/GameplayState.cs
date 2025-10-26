using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class GameplayState : BaseState
{

    private GameManager gameManager;

    int answerCount;
    List<string> shuffledAnswers;
    List<Transform> shuffledSpawns;

    public Questions[] questionArray;
    public static List<Questions> unansweredQuestions;
    public Questions currentQuestion;

    [SerializeField] private GameObject answerButtonPrefab;
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private float buttonSpawnDelay = 2f;

    [SerializeField] private Text questionText;

    [SerializeField] GameObject GameOver;

    public List<AnswerButton> activeButtons = new List<AnswerButton>();
    public override void StartState()
    {
        unansweredQuestions = questionArray.ToList();

        //1
        if (unansweredQuestions?.Count == 0)
        {
            Debug.Log("All questions answered!");
            GameOver.SetActive(true);
        }

        int randomQuestionIndex = Random.Range(0, unansweredQuestions.Count);
        currentQuestion = unansweredQuestions[randomQuestionIndex];

        questionText.text = currentQuestion.question;

        //2
        SpawnAnswers();
        
        //StartCoroutine(SpawnButtonsCoroutine(answerCount, shuffledAnswers, shuffledSpawns));

        Debug.Log($"{currentQuestion.question} - Correct answer: {currentQuestion.Answers[0]} (spawn index {currentQuestion.correctAnswerIndex})");
    }
    public override bool UpdateState()
    {
        
        answerCount = currentQuestion.Answers.Length;

        for (int i = 0; i < answerCount; i++)
        {
            Debug.Log($"Spawning answer button");

            GameObject newButton = Instantiate(answerButtonPrefab, shuffledSpawns[i]);
            RectTransform rect = newButton.GetComponent<RectTransform>();
            rect.localPosition = Vector3.zero;
            rect.localRotation = Quaternion.identity;
            rect.localScale = Vector3.one;

            AnswerButton answerBtn = newButton.GetComponent<AnswerButton>();
            answerBtn.Initialize(gameManager, shuffledAnswers[i], i);
            activeButtons.Add(answerBtn);

        }
        /*for (int i = 0; i < answerCount; i++)
        {
            Vector3 spawnPosition = Vector3.zero;
            GameObject newButton = Instantiate(answerButtonPrefab, spawnPosition, Quaternion.identity, shuffledSpawns[i]);
            
            AnswerButton answerBtn = newButton.GetComponent<AnswerButton>();
            answerBtn.Initialize(gameManager, shuffledAnswers[i], i);

            activeButtons.Add(answerBtn);

         }*/
        return false;
    }
    public override int Finish()
    {
        return 1;
    }

    private void SpawnAnswers()
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
    }
}
