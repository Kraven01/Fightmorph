using UnityEngine;

public class SlimeBossHealth : EnemyHealth
{
    private bool firstMechPlayed;
    public TextMesh health;
    private bool secondMechPlayed;
    public SlimeBossCombat slimeBossCombat;

    public void Start()
    {
        this.slimeBossCombat = this.GetComponent<SlimeBossCombat>();
        this.health.text = $"{this.currentHealth}/{this.maxHealth}";
    }

    public void FixedUpdate()
    {
        if (this.currentHealth > 0)
        {
            this.health.text = $"{this.currentHealth}/{this.maxHealth}";
        }
    }
}