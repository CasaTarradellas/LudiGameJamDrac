// GameplayState.cs (cambios clave)
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class GameplayState : BaseState
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private GameObject answerButtonPrefab;
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private Text questionText;
    [SerializeField] GameObject GameOver;
    [SerializeField] GameObject GameLose;
    private StarGetter starGetter;


    [SerializeField] private float spawnDelay = 2.0f;
    private Coroutine spawnRoutine;

    public Questions[] questionArray;
    public static List<Questions> unansweredQuestions;
    public Questions currentQuestion;

    List<string> shuffledAnswers;
    List<Transform> shuffledSpawns;

    public List<AnswerButton> activeButtons = new List<AnswerButton>();

    [SerializeField] private float nextQuestionDelay = 0.6f;
    private bool awaitingNext = false;

    [SerializeField] private ScoreMaster scoreMaster;

    public override void StartState()
    {
        if (gameManager == null) gameManager = FindFirstObjectByType<GameManager>();

        unansweredQuestions = questionArray?.ToList();

        int randomQuestionIndex = Random.Range(0, unansweredQuestions.Count);
        currentQuestion = unansweredQuestions[randomQuestionIndex];

        if (questionText) questionText.text = currentQuestion.question;

        SpawnAnswers();
    }

    public override bool UpdateState()
    {
        return false;
    }

    private void SpawnAnswers()
    {
        foreach (var sp in spawnPoints)
            for (int i = sp.childCount - 1; i >= 0; i--)
                Destroy(sp.GetChild(i).gameObject);

        int answerCount = currentQuestion.Answers.Length;
        if (answerCount > spawnPoints.Length)
        {
            Debug.LogWarning("Not enough spawn points! Reducing to available spawn points.");
            answerCount = spawnPoints.Length;
        }

        shuffledAnswers = currentQuestion.Answers.OrderBy(_ => Random.value).ToList();
        shuffledSpawns = spawnPoints.OrderBy(_ => Random.value).Take(answerCount).ToList();

        currentQuestion.correctAnswerIndex = shuffledAnswers.IndexOf(currentQuestion.Answers[0]);

        var toSpawn = new List<(string answer, Transform spawn)>();
        for (int i = 0; i < answerCount; i++)
            toSpawn.Add((shuffledAnswers[i], shuffledSpawns[i]));

        if (spawnRoutine != null) StopCoroutine(spawnRoutine);
        spawnRoutine = StartCoroutine(SpawnAnswersStaggered(toSpawn));

        Debug.Log($"{currentQuestion.question} - Correct answer: {currentQuestion.Answers[0]}");
    }
    private IEnumerator SpawnAnswersStaggered(List<(string answer, Transform spawn)> items)
    {
        activeButtons.Clear();

        for (int i = 0; i < items.Count; i++)
        {
            GameObject go = Instantiate(answerButtonPrefab, items[i].spawn);

            var rect = go.GetComponent<RectTransform>();
            if (rect != null)
            {
                rect.anchoredPosition3D = Vector3.zero;
                rect.localRotation = Quaternion.identity;
                rect.localScale = Vector3.one;
            }

            var btn = go.GetComponent<AnswerButton>();
            btn.Initialize(gameManager, items[i].answer, i);
            activeButtons.Add(btn);

            yield return new WaitForSeconds(spawnDelay);
        }

        spawnRoutine = null; 
    }
    public override int Finish()
    {
        if (spawnRoutine != null) { StopCoroutine(spawnRoutine); spawnRoutine = null; }
        return 1;
    }

    public void OnAnswerSelected(int selectedIndex)
    {
        if (awaitingNext || currentQuestion == null) return;

        bool correct = (selectedIndex == currentQuestion.correctAnswerIndex);

        if (correct) {
            scoreMaster.addPoints();
            Debug.Log("Correct answer selected!");
            //Debug.Log("Score: " + scoreMaster);
        }
        else 
        {
            scoreMaster.loseLife();
            Debug.Log("Wrong answer selected!");
            //Debug.Log("Lives left: " + scoreMaster);
        }

        HighlightButtons(currentQuestion.correctAnswerIndex, selectedIndex);

        SetButtonsInteractable(false);

        StartCoroutine(NextQuestionRoutine());
    }

    private IEnumerator NextQuestionRoutine()
    {
        awaitingNext = true;
        yield return new WaitForSeconds(nextQuestionDelay);


        if (unansweredQuestions != null && currentQuestion != null)
            unansweredQuestions.Remove(currentQuestion);


        if (unansweredQuestions == null || unansweredQuestions.Count == 0)
        {

            if (GameOver)
            {
                GameOver.SetActive(true);
                starGetter.starDisplay();
                Time.timeScale = 0f;
            }
            awaitingNext = false;
            yield break;
        }


        if (scoreMaster.getLife() == 0)
        {
            GameLose.SetActive(true);
            starGetter.starDisplay();
            Time.timeScale = 0f;
        }

        LoadNextQuestion();
        awaitingNext = false;
    }

    private void LoadNextQuestion()
    {
        for (int i = activeButtons.Count - 1; i >= 0; i--)
            if (activeButtons[i]) Destroy(activeButtons[i].gameObject);
        activeButtons.Clear();

        int idx = Random.Range(0, unansweredQuestions.Count);
        currentQuestion = unansweredQuestions[idx];

        if (questionText) questionText.text = currentQuestion.question;

        SpawnAnswers();
    }

    private void HighlightButtons(int correctIndex, int selectedIndex)
    {
        for (int i = 0; i < activeButtons.Count; i++)
        {
            var ab = activeButtons[i];
            if (!ab) continue;

            bool isCorrect = (i == correctIndex);
            bool isSelected = (i == selectedIndex);

            var uiBtn = ab.GetComponent<UnityEngine.UI.Button>();
            if (uiBtn) uiBtn.interactable = isCorrect; 
        }
    }

    private void SetButtonsInteractable(bool interactable)
    {
        for (int i = 0; i < activeButtons.Count; i++)
        {
            var uiBtn = activeButtons[i]?.GetComponent<UnityEngine.UI.Button>();
            if (uiBtn) uiBtn.interactable = interactable;
        }
    }
}
