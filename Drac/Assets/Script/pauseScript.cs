using UnityEngine;
using UnityEngine.InputSystem;

public class pauseScript : MonoBehaviour
{
    public void PauseGame()
    {
        Time.timeScale = 0f;
        Cursor.visible = true;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        Cursor.visible = false;
    }
}
