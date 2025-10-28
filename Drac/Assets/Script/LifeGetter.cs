using UnityEngine;
using UnityEngine.UI;

public class LifeGetter : MonoBehaviour
{
    [SerializeField]private ScoreMaster scoreMaster;

    [SerializeField] private Image heart1;
    [SerializeField] private Image heart2;
    [SerializeField] private Image heart3;
    void Update()
    {
        lifeDisplay();
    }

    void lifeDisplay()
    {
        heart1.enabled = true;
        heart2.enabled = true;
        heart3.enabled = true;

        if (scoreMaster != null)
        {
            switch(scoreMaster)
            {
                case { life: 2 }:
                    heart3.enabled = false;
                    break;
                case { life: 1 }:
                    heart2.enabled = false;
                    heart3.enabled = false;
                    break;
                case { life: 0 }:
                    heart1.enabled = false;
                    heart2.enabled = false;
                    heart3.enabled = false;
                    break;
            }
        }
    }
}
