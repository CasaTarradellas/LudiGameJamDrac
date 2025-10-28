using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreDisplay : MonoBehaviour
{
    [SerializeField]private ScoreMaster scoreMaster;
    [SerializeField]public TextMeshProUGUI scoreText;

    void Update()
    {
        scoreText.text = "Score: " + scoreMaster.score.ToString();
    }
}
