using UnityEngine;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
    [SerializeField] private AudioSource effectMixer;

    [SerializeField] private Slider effectSlider;
    [SerializeField] private AudioSource musicMixer;
    [SerializeField] private Slider musicSlider;

    // Start is called before the first frame update
    private void Awake()
    {
        this.effectSlider.value = PlayerPrefs.GetFloat("SoundEffects", 0.5f);
        this.musicSlider.value = PlayerPrefs.GetFloat("Music", 0.5f);
    }

    public void SetMusic(float volume)
    {
        if (this.musicMixer != null)
        {
            this.musicMixer.volume = volume;
        }

        PlayerPrefs.SetFloat("Music", volume);
    }

    public void SetSound(float volume)
    {
        if (this.effectMixer != null)
        {
            this.effectMixer.volume = volume;
        }

        PlayerPrefs.SetFloat("SoundEffects", volume);
    }
}