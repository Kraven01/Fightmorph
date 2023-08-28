using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    public AudioClip attackSound;

    private AudioSource audioSource;

    // Start is called before the first frame update
    private void Start()
    {
        this.audioSource = this.GetComponent<AudioSource>();
    }

    public void PlayAttackSound()
    {
        this.audioSource.clip = this.attackSound;
        this.audioSource.Play();
    }
}