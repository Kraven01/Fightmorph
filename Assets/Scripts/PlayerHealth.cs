using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : Health
{ 

    public TextMesh health;
    public override void Awake()
    {
        maxHealth = 10;
        damageNumberColor = Color.red;
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
    }

    
}
