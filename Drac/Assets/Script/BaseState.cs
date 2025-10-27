using UnityEngine;

public abstract class BaseState : MonoBehaviour
{
    public abstract void StartState();
    public abstract bool UpdateState(); //IF return == TRUE -> Change State
    public abstract int Finish(); // Return indicates next state index in states array of manager
}
