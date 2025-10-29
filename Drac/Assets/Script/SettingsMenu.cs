using UnityEngine;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{

    public AudioMixer audioMixer;

    public AudioSource musicSource;
    public AudioSource soundEffect;
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }
}
