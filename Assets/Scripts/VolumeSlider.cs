using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeControl : MonoBehaviour
{
    public AudioMixer mixer; // Assign your AudioMixer in inspector
    public Slider volumeSlider; // Assign your UI slider

    void Start()
    {
        // Initialize slider from saved preferences
        float savedVolume = PlayerPrefs.GetFloat("MasterVolume", 0f);
        volumeSlider.value = savedVolume;
        SetVolume(savedVolume);

        // Update volume when slider changes
        volumeSlider.onValueChanged.AddListener(SetVolume);
    }

    public void SetVolume(float volume)
    {
        mixer.SetFloat("MasterVolume", volume); // Make sure name matches exposed parameter
        PlayerPrefs.SetFloat("MasterVolume", volume); // Optional: save setting
    }
}
