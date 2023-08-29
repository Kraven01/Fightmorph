using UnityEngine;
using UnityEngine.UI;

public class VolumeController : MonoBehaviour
{
    [SerializeField] private AudioSource audioMixer;

    [SerializeField] private Slider volumeSlider;

    // Start is called before the first frame update
    private void Start()
    {
        this.volumeSlider.value = this.audioMixer.volume;
    }

    public void SetVolume(float volume)
    {
        this.audioMixer.volume = volume;
    }
}