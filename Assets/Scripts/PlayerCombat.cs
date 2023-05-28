using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : Combat
{
    public int attackDamage;
    public int baseAttackDamage = 6;
    public PlayerStats playerStats;

    public override void Start()
    {
        base.Start();
        targetLayer = LayerMask.GetMask("Enemies");
        cooldown = 1f;
        attackRange = 0.5f;
        xRange = 1.2f;
        yRange = -0.5f;
        attackDamage = baseAttackDamage;
        playerStats = GetComponent<PlayerStats>();
    }

    // Update is called once per frame
    public override void Update()
    {
        if (canAttack && (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)))
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

    public override Collider2D[] computeTargets()
    {
        if (right)
        {
            Vector3 parentPos = attackPoint.parent.position + new Vector3(xRange, yRange, 0f);
            attackPoint.position = parentPos;
            return Physics2D.OverlapCircleAll(attackPoint.position, attackRange, targetLayer);
        }
        else
        {
            Vector3 parentPos = attackPoint.parent.position + new Vector3(-xRange, yRange, 0f);
            attackPoint.position = parentPos;
            return Physics2D.OverlapCircleAll(attackPoint.position, attackRange, targetLayer);
        }
    }

    public void SyncStats()
     {
        attackDamage = baseAttackDamage + playerStats.strength;
      }
}
