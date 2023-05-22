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
    public bool dead = false;

    public float xRange;
    public float yRange;


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
        hitTargets = computeTargets();

        // Calculate damage
        foreach (Collider2D target in hitTargets)
        {
            dealDamage(target);
        }

        yield return new WaitForSeconds(cooldown);
        canAttack = true;
    }

    public abstract void dealDamage(Collider2D target);

    //private void OnDrawGizmos()
    //{
      //  Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    //}

    public abstract Collider2D[] computeTargets();
}
