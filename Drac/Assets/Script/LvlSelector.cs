using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LvlSelector : MonoBehaviour
{
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1f;
    }

    public void NextLevel1()
    {
        SceneManager.LoadScene("Nivell_1");
        Time.timeScale = 1f;
    }

    public void NextLevel2()
    {
        SceneManager.LoadScene("Nivell_2");
        Time.timeScale = 1f;
    }

    public void LVLSelector()
    {
        SceneManager.LoadScene("LvlSelector");
        Time.timeScale = 1f;
    }

    public void AnimacionScene()
    {
        SceneManager.LoadScene("AnimacionHistoria");
        Time.timeScale = 1f;
    }
}
