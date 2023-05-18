using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Health : MonoBehaviour, IHealth
{
    protected int maxHealth = 10;
    protected int currentHealth;

    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    public virtual void takeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            die();
        }
        else 
        {
            animator.SetTrigger("hurt");
        }
    }

    public virtual void heal(int amount)
    {
        currentHealth += amount;
    }

    public virtual void die()
    {
        animator.SetTrigger("death");
    }
}
