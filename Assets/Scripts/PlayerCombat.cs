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
    }

    // Update is called once per frame
    public override void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GetComponent<AudioPlayer>().PlayAttackSound();
            Attack();
        }
    }

    public override void dealDamage(Collider2D target)
    {
        EnemyHealth enemyHealth = target.GetComponent<EnemyHealth>();
        enemyHealth.takeDamage(attackDamage);
    }
}
