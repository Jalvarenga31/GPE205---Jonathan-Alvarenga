using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class OptionsScreenUI : MonoBehaviour
{

    public AudioMixer mainAudioMixer;
    public Slider mainVolumeSlider;

    public void Start()
    {
        OnMainVolumeChange();
        MusicVolumeChange();
        SFXVolumeChange();
    }

    public void OnMainVolumeChange()
    {
        float newVolume = mainVolumeSlider.value;
        if (newVolume <= 0)
        {
            newVolume = -80;
        }
        else
        {
            newVolume = Mathf.Log10(newVolume);
            newVolume = newVolume * 20;
        }
        mainAudioMixer.SetFloat("MasterVolume", newVolume);
    }
    public void MusicVolumeChange()
    {
        float newVolume = mainVolumeSlider.value;
        if (newVolume <= 0)
        {
            newVolume = -80;
        }
        else
        {
            newVolume = Mathf.Log10(newVolume);
            newVolume = newVolume * 20;
        }
        mainAudioMixer.SetFloat("MusicVolume", newVolume);
    }

    public void SFXVolumeChange()
    {
        float newVolume = mainVolumeSlider.value;
        if (newVolume <= 0)
        {
            newVolume = -80;
        }
        else
        {
            newVolume = Mathf.Log10(newVolume);
            newVolume = newVolume * 20;
        }
        mainAudioMixer.SetFloat("SoundEffectsVolume", newVolume);
    }

}