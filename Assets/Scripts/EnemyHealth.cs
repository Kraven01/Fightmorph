using UnityEngine;

public class EnemyHealth : Health
{
    private PlayerStats playerStats;

    public override void Awake()
    {
        this.damageNumberColor = Color.white;
        this.playerStats = GameObject.Find("KnightPlayer").GetComponent<PlayerStats>();
        base.Awake();
    }

    public override void die()
    {
        this.playerStats.StartCoroutine(this.playerStats.AddExperience(20));
        base.die();
    }
}