using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuController : MonoBehaviour
{
    public void Start()
    {
        PlayerPrefs.SetFloat("Music", 0.25f);
        PlayerPrefs.SetFloat("SoundEffects", 0.25f);
    }

    public void Continue()
    {
    }

    public void NewGame()
    {
        SceneManager.LoadScene("IntroLevel");
    }


    public void QuitGame()
    {
        Application.Quit();
    }
}