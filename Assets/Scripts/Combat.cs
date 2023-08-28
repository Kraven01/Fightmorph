using System.Collections;
using UnityEngine;

public abstract class Combat : MonoBehaviour
{
    public Animator animator;

    public Transform attackPoint;
    public float attackRange;
    public bool canAttack = true;

    public float cooldown;
    public bool dead = false;

    public bool right = true;

    public LayerMask targetLayer;

    public float xRange;
    public float yRange;


    public virtual void Start()
    {
        this.attackPoint = this.transform.Find("attackPoint");
        this.animator = this.GetComponent<Animator>();
    }

    // Update is called once per frame
    public abstract void Update();

    public virtual IEnumerator Attack()
    {
        this.canAttack = false;
        // start attack animation
        this.animator.SetTrigger("attack");
        Collider2D[] hitTargets;
        // Compute enemies in range
        hitTargets = this.computeTargets();

        // Calculate damage
        foreach (Collider2D target in hitTargets)
        {
            this.dealDamage(target);
        }

        yield return new WaitForSeconds(this.cooldown);
        this.canAttack = true;
    }

    public abstract void dealDamage(Collider2D target);

    //private void OnDrawGizmos()
    //{
    //  Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    //}

    public abstract Collider2D[] computeTargets();
}