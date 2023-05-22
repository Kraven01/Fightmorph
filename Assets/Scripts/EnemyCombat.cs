using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombat : Combat
{
    Transform target;
    public int attackDamage = 3;
    float attackTriggerRange = 3f;
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        targetLayer = LayerMask.GetMask("Player");
        target = GameObject.Find("KnightPlayer").transform;
        cooldown = 2f;
        xRange = 1.2f;
        yRange = -0.5f;
    }

    // Update is called once per frame
    public override void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, target.position);
        if (canAttack && !dead && distanceToPlayer <=attackTriggerRange)
        {
            GetComponent<AudioPlayer>().PlayAttackSound();
            StartCoroutine(Attack());
        }
    }

    public override void dealDamage(Collider2D target)
    {
        PlayerHealth playerHealth = target.GetComponent<PlayerHealth>();
        playerHealth.takeDamage(attackDamage);
    }

    public override Collider2D[] computeTargets()
    {
        return Physics2D.OverlapCircleAll(attackPoint.position, attackRange, targetLayer);
        
    }

    
}
