using UnityEngine;

public class LifeGetter : MonoBehaviour
{
    ScoreMaster scoreMaster;
    void Start()
    {
        scoreMaster = FindFirstObjectByType<ScoreMaster>();
    }
    void Update()
    {
        lifeDisplay();
    }

    void lifeDisplay()
    {
        if (scoreMaster != null)
        {
            switch(scoreMaster)
            {
                case { life: 2 }:
                    GameObject.Find("Corazon3").SetActive(false);
                    break;
                case { life: 1 }:
                    GameObject.Find("Corazon2").SetActive(false);
                    break;
                case { life: 0 }:
                    GameObject.Find("Corazon1").SetActive(false);
                    break;
            }
        }
    }
}
