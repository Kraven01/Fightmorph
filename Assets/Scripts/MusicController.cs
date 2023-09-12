using UnityEngine;

public class MusicController : MonoBehaviour
{
    private AudioSource audioSource;

    // Start is called before the first frame update
    private void Start()
    {
        this.audioSource = this.GetComponent<AudioSource>();
        this.audioSource.volume = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>()
            .MusicVolume;
        GameController.OnMusicVolumeChanged += this.AdjustMusicVolume;
    }

    private void AdjustMusicVolume(float newValue)
    {
        this.audioSource.volume = newValue;
    }
}