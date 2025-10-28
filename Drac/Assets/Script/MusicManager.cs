using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private static MusicManager instance;

    void Awake()
    {
        // Evitar duplicados al volver a cargar la escena
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
