using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
//using static UnityEditor.VersionControl.Asset;

public class GameManager : MonoBehaviour
{
    private bool dracIdle = true;
    [SerializeField] private GameplayState gameplayState;

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
        if (gameplayState != null)
            gameplayState.OnAnswerSelected(answerNumber);
        else
            Debug.LogWarning("GameplayState no asignado en GameManager.");
    }
}
