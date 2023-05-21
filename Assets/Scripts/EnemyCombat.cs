using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCombat : Combat
{
    public int attackDamage = 3;
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        targetLayer = LayerMask.GetMask("Player");
        cooldown = 2f;
    }

    // Update is called once per frame
    public override void Update()
    {
        if (canAttack)
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

    
}
