using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LvlSelector : MonoBehaviour
{
    public GameObject lvlButtonPrefab;
    public Transform buttonContainer;
    public int totalLvls = 2;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GenerateLvlButtons();
    }

    void GenerateLvlButtons()
    {
        for (int i = 1; i < totalLvls + 1; i++)
        {
            GameObject buttonObj = Instantiate(lvlButtonPrefab, buttonContainer);
            buttonObj.GetComponentInChildren<TextMeshProUGUI>().text = "Nivell " + i;

            int lvlIndex = i;

            buttonObj.GetComponent<Button>().onClick.AddListener(() =>
            {
                SceneManager.LoadScene("Nivell_" +  lvlIndex);
            });
        }
    }
}
