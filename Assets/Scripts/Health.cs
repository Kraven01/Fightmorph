using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Health : MonoBehaviour, IHealth
{
    protected int maxHealth = 10;
    protected int currentHealth;
    protected BoxCollider2D boxCollider;

    public GameObject damageNumberPrefab;

    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        boxCollider = GetComponent<BoxCollider2D>();
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
        GetComponent<Movement>().dead = true;
        GetComponent<Movement>().movement = new Vector2(0f, 0f);
        boxCollider.enabled = false;
        Destroy(boxCollider.gameObject, 10f);
    }
}
