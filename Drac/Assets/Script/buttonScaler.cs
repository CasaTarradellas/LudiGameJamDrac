using UnityEngine;

public class buttonScaler : MonoBehaviour
{
    private Camera mainCamera;
    public float referenceOrthoSize = 5f;
    public float baseScale = 1f;

    void Start()
    {
        mainCamera = Camera.main;   
        AdjustScale();
    }

    void AdjustScale()
    {
        float scaleFactor = mainCamera.orthographicSize / referenceOrthoSize;
        transform.localScale = Vector3.one * baseScale * scaleFactor;
    }
}

