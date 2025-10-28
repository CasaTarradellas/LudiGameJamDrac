using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LvlSelector : MonoBehaviour
{
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void NextLevel1()
    {
        SceneManager.LoadScene("Nivell_1");
    }

    public void NextLevel2()
    {
        SceneManager.LoadScene("Nivell_2");
    }
}
