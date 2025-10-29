using UnityEngine;
using UnityEngine.UI;

public class StarGetter : MonoBehaviour
{
    [SerializeField] private GameObject GameOver;
    [SerializeField] private ScoreMaster scoreMaster;
    [SerializeField] private Image star1;
    [SerializeField] private Image star2;
    [SerializeField] private Image star3;

    public void starDisplay()
    {
        star1.enabled = false;
        star2.enabled = false;
        star3.enabled = false;

        Cursor.visible = true;

        Debug.Log(scoreMaster);
        switch (scoreMaster)
            {
                case { score: 8 }:
                    star1.enabled = true;
                    Debug.Log("1 star");
                    break;
                case { score: 9 }:
                    star1.enabled = true;
                    star2.enabled = true;
                    Debug.Log("2 star");
                    break;
                case { score: 10 }:
                    star1.enabled = true;
                    star2.enabled = true;
                    star3.enabled = true;
                    Debug.Log("3 star");
                    break;
            }
    }
}
