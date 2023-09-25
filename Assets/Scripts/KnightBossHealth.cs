using UnityEngine;

public class KnightBossHealth : EnemyHealth
{
    private bool firstMechPlayed;
    public TextMesh health;
    public KnightBossCombat knightBossCombat;
    private bool secondMechPlayed;

    public void Start()
    {
        this.knightBossCombat = this.GetComponent<KnightBossCombat>();
        this.health.text = $"{this.currentHealth}/{this.maxHealth}";
    }

    public void FixedUpdate()
    {
        if (this.currentHealth > 0)
        {
            this.health.text = $"{this.currentHealth}/{this.maxHealth}";
        }
    }

    public override void takeDamage(int damage)
    {
        base.takeDamage(damage);

        // Play first mech once below 66%
        if (!this.firstMechPlayed && this.currentHealth <= 0.66f * this.maxHealth)
        {
            this.firstMechPlayed = true;
            this.StartCoroutine(this.knightBossCombat.BossMechanic(20, 3));
            return;
        }

        // Play second mech once below 33%
        if (!this.secondMechPlayed && this.currentHealth <= 0.33f * this.maxHealth)
        {
            this.secondMechPlayed = true;
            this.StartCoroutine(this.knightBossCombat.BossMechanic(45, 5));
        }
    }
}