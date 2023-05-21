using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Combat : MonoBehaviour
{

    public Animator animator;

    public Transform attackPoint;
    public float attackRange = 0.5f;

    public bool right = true;

    public LayerMask targetLayer;

    public virtual void Start()
    {
        attackPoint = transform.Find("attackPoint");
    }
    
    // Update is called once per frame
    public abstract void Update();

    public virtual void Attack()
    {
        // start attack animation
        animator.SetTrigger("attack");
        Collider2D[] hitTargets;
        // Compute enemies in range
        if (right){
            Vector3 parentPos = attackPoint.parent.position + new Vector3(1.2f,-0.5f,0f);
            attackPoint.position = parentPos;
            hitTargets =  Physics2D.OverlapCircleAll(attackPoint.position, attackRange, targetLayer);
        } else {
            Vector3 parentPos = attackPoint.parent.position + new Vector3(-1.2f,-0.5f,0f);
            attackPoint.position = parentPos;
            hitTargets =  Physics2D.OverlapCircleAll(attackPoint.position, attackRange, targetLayer);
        }

        // Calculate damage
        foreach (Collider2D target in hitTargets)
        {
            dealDamage(target);
        }
    }

    public abstract void dealDamage(Collider2D target);
}
