using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{

    public Animator animator;

    public Transform attackPointRight;
    public Transform attackPointLeft;
    public float attackRange = 0.5f;

    public bool right = true;

    public LayerMask enemyLayers;
    // Start is called before the first frame update
    void Start()
    {
        
    
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GetComponent<AudioPlayer>().PlayAttackSound();
            Attack();
        }
    }

    void Attack()
    {
        // start attack animation
        animator.SetTrigger("attack");
        Collider2D[] hitEnemies;
        // Compute enemies in range
        if (right){
            hitEnemies =  Physics2D.OverlapCircleAll(attackPointRight.position, attackRange, enemyLayers);
        } else {
            hitEnemies =  Physics2D.OverlapCircleAll(attackPointLeft.position, attackRange, enemyLayers);
        }

        // Calculate damage
        foreach (Collider2D enemy in hitEnemies)
        {
            EnemyHealth enemyHealth = enemy.GetComponent<EnemyHealth>();
            enemyHealth.takeDamage(6);
        }
    }
}
