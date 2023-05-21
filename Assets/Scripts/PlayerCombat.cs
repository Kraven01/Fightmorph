using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : Combat
{
    public int attackDamage = 6;

    public override void Start()
    {
        base.Start();
        targetLayer = LayerMask.GetMask("Enemies");
        cooldown = 1f;
    }

    // Update is called once per frame
    public override void Update()
    {
        if (canAttack && Input.GetMouseButtonDown(0))
        {
            GetComponent<AudioPlayer>().PlayAttackSound();
            StartCoroutine(Attack());
        }
    }

    public override void dealDamage(Collider2D target)
    {
        EnemyHealth enemyHealth = target.GetComponent<EnemyHealth>();
        enemyHealth.takeDamage(attackDamage);
    }
}
