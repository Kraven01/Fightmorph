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

    public float cooldown;
    public bool canAttack = true;

    public virtual void Start()
    {
        attackPoint = transform.Find("attackPoint");
        animator = GetComponent<Animator>();
    }
    
    // Update is called once per frame
    public abstract void Update();

    public virtual  IEnumerator Attack()
    {
        canAttack = false;
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

        yield return new WaitForSeconds(cooldown);
        canAttack = true;
    }

    public abstract void dealDamage(Collider2D target);
}
