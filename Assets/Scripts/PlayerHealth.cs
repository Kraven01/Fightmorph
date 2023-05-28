using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : Health
{ 

    [SerializeField]
    private StatSelecter statSelecter;

    public PlayerStats playerStats;

    public TextMesh health;
    public override void Awake()
    {

        baseHealth = 10;
        maxHealth = baseHealth;
        damageNumberColor = Color.red;
        playerStats = GetComponent<PlayerStats>();
        base.Awake();
        health.text = string.Format("{0}/{1}",currentHealth,maxHealth);
    }

    public void FixedUpdate()
    {
        health.text = string.Format("{0}/{1}",currentHealth,maxHealth);
    }

    public void LevelUp()
    {
        currentHealth = maxHealth;
        healthbar.SetHealth(currentHealth);
        statSelecter.syncStats();
    }

    public void SyncStats()
    {
        maxHealth = baseHealth + playerStats.vitality;
    }

    
}
