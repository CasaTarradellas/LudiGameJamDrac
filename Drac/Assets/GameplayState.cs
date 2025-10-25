using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class GameplayState : BaseState
{
    int answerCount;
    List<string> shuffledAnswers;
    List<Transform> shuffledSpawns;

    public Questions[] questionArray;
    private static List<Questions> unansweredQuestions;
    private Questions currentQuestion;

    [SerializeField] private GameObject answerButtonPrefab;
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private float buttonSpawnDelay = 2f;

    [SerializeField] private Text questionText;

    [SerializeField] GameObject GameOver;

    private List<AnswerButton> activeButtons = new List<AnswerButton>();
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

        //SpawnAnswers();

        //2
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
    public override bool UpdateState()
    {
        for (int i = 0; i < answerCount; i++)
        {
            Vector3 spawnPosition = Vector3.zero;//Random spawner;
            GameObject newButton = Instantiate(answerButtonPrefab, spawnPosition, Quaternion.identity, shuffledSpawns[i]);

            AnswerButton answerBtn = newButton.GetComponent<AnswerButton>();
            //answerBtn.Initialize(this, shuffledAnswers[i], i);
            activeButtons.Add(answerBtn);

        }
        return false;
    }
    public override int Finish()
    {
        return 1;
    }
}
