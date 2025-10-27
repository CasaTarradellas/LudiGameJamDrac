
using UnityEngine;

[System.Serializable]
public class Questions
{
    public string question;
    public string[] Answers;

    [HideInInspector] public int correctAnswerIndex; 
}
