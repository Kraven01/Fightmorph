using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    public AudioClip attackSound;

    private AudioSource audioSource;
    public AudioClip explosionSound;
    public AudioClip fireBallSound;

    // Start is called before the first frame update
    private void Start()
    {
        this.audioSource = this.GetComponent<AudioSource>();
        this.audioSource.volume = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>()
            .EffectVolume;
        GameController.OnEffectVolumeChanged += this.AdjustEffectVolume;
    }

    public void PlayAttackSound()
    {
        this.audioSource.clip = this.attackSound;
        this.audioSource.Play();
    }

    public void PlayFireCastSound()
    {
        this.audioSource.clip = this.fireBallSound;
        this.audioSource.Play();
    }

    public void PlayExplosionSound()
    {
        this.audioSource.clip = this.explosionSound;
        this.audioSource.Play();
    }

    private void AdjustEffectVolume(float newValue)
    {
        this.audioSource.volume = newValue;
    }
}