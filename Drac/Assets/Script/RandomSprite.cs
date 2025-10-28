using UnityEngine;
using UnityEngine.UI;

public class RandomSprite : MonoBehaviour
{
    public Sprite[] buttonSprites;
    public Image targetButtonImage;

    void Start()
    {
        ChangeSprite();
    }

    public void ChangeSprite()
    {
        if (buttonSprites.Length > 0 && targetButtonImage != null)
        {
            // Genera un �ndice aleatorio
            int randomIndex = Random.Range(0, buttonSprites.Length);

            // Asigna el sprite aleatorio al bot�n
            targetButtonImage.sprite = buttonSprites[randomIndex];
        }
    }
}
