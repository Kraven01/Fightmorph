using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : Health
{
    PlayerStats playerStats;
    public override void Awake()
    {
        maxHealth = 15;
        damageNumberColor = Color.white;
        playerStats = GameObject.Find("KnightPlayer").GetComponent<PlayerStats>();
        base.Awake();
    }

    public override void die()
    {
        playerStats.StartCoroutine(playerStats.AddExperience(2));
        base.die();
    }
    
}
