using UnityEngine;

public class GameController : MonoBehaviour
{
    private bool isPaused;
    private PlayerCombat playerCombat;

    public void Start()
    {
        this.playerCombat = this.gameObject.GetComponent<PlayerCombat>();
    }

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
}