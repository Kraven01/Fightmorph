using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public delegate void EffectVolumeChanged(float newEffectVolume);

    public delegate void MusicVolumeChanged(float newMusicVolume);

    private float effectVolume;
    private bool isPaused;
    private float musicVolume;
    private PlayerCombat playerCombat;

    public float EffectVolume
    {
        get => this.effectVolume;
        set
        {
            if (this.effectVolume != value)
            {
                this.effectVolume = Mathf.Clamp01(value);
                PlayerPrefs.SetFloat("SoundEffects", value);
                OnEffectVolumeChanged?.Invoke(this.effectVolume);
            }
        }
    }

    public float MusicVolume
    {
        get => this.musicVolume;
        set
        {
            if (this.musicVolume != value)
            {
                this.musicVolume = Mathf.Clamp01(value);
                PlayerPrefs.SetFloat("Music", value);
                OnMusicVolumeChanged?.Invoke(this.musicVolume);
            }
        }
    }

    public void Start()
    {
        this.playerCombat = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerCombat>();
        this.effectVolume = PlayerPrefs.GetFloat("SoundEffects", 0.5f);
        this.musicVolume = PlayerPrefs.GetFloat("Music", 0.5f);
    }

    public static event EffectVolumeChanged OnEffectVolumeChanged;

    public static event MusicVolumeChanged OnMusicVolumeChanged;

    public void TogglePause()
    {
        this.isPaused = !this.isPaused;
        if (this.isPaused)
        {
            Time.timeScale = 0f;
            this.PauseGame();
        }
        else
        {
            Time.timeScale = 1f;
            this.ResumeGame();
        }
    }

    private void PauseGame()
    {
        this.playerCombat.canAttack = false;
    }

    private void ResumeGame()
    {
        this.playerCombat.canAttack = true;
    }

    public void BackToMenu()
    {
        // Save Logic
        SceneManager.LoadScene("StartMenu");
    }

    public void QuitGame()
    {
        // Save Logic
        Application.Quit();
    }
}