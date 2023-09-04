using UnityEngine;

public class PlayerHealth : Health
{
    public TextMesh health;

    public PlayerStats playerStats;

    [SerializeField] private StatSelecter statSelecter;

    public override void Awake()
    {
        this.baseHealth = 10;
        this.maxHealth = this.baseHealth;
        this.damageNumberColor = Color.red;
        this.playerStats = this.GetComponent<PlayerStats>();
        base.Awake();
        this.health.text = string.Format("{0}/{1}", this.currentHealth, this.maxHealth);
    }

    public void FixedUpdate()
    {
        this.health.text = string.Format("{0}/{1}", this.currentHealth, this.maxHealth);
    }

    public void LevelUp()
    {
        this.currentHealth = this.maxHealth;
        this.Healthbar.SetHealth(this.currentHealth);
        this.statSelecter.syncStats();
    }

    public void SyncStats()
    {
        this.maxHealth = this.baseHealth + this.playerStats.vitality;
    }
}