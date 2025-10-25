using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using static UnityEditor.VersionControl.Asset;

public class GameManager : MonoBehaviour
{
    public Questions[] questionArray;
    private static List<Questions> unansweredQuestions;
    private Questions currentQuestion;

    [SerializeField] private GameObject answerButtonPrefab;
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private float buttonSpawnDelay = 2f;

    [SerializeField] private Text questionText;

    [SerializeField] GameObject GameOver;

    private List<AnswerButton> activeButtons = new List<AnswerButton>();

    int currentState = 0;

    [SerializeField] private BaseState[] states;


    void Start()
    {
        states[currentState].StartState();
    }
    void Update()
    {
        if (states[currentState].UpdateState())
        {
            currentState = states[currentState].Finish();
            states[currentState].StartState();
        }
    }
 
    public void userSelectedAnswer(int answerNumber)
    {   
        if (answerNumber == currentQuestion.correctAnswerIndex)
        {
            Debug.Log("Correct!");
        }
        else
        {
            Debug.Log("Wrong!");
        }

        //StartCoroutine(TransitionNextQuestion());
    }
}
