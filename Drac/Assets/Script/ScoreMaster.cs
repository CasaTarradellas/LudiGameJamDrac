using UnityEngine;

public class ScoreMaster : MonoBehaviour
{
    [SerializeField] public int score;
    [SerializeField] public int life = 3;
    public int addPoints()
    {
        score += 1;
        return score;
    }

    public int loseLife()
    {
        life -= 1;
        return life;
    }

    public int getLife()
    {
        return life;
    }
}
