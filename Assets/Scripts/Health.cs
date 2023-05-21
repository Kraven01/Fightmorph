using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class Health : MonoBehaviour, IHealth
{
    public int maxHealth;
    protected int currentHealth;
    protected BoxCollider2D boxCollider;
    public HealthBar healthbar;

    public GameObject damageNumberPrefab;

    public Animator animator;
    public Color damageNumberColor;

    public virtual void Awake()
    {
        currentHealth = maxHealth;
        animator = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
        healthbar = GetComponentInChildren<HealthBar>();
        healthbar.SetMaxHealth(maxHealth);
    }

    public virtual void takeDamage(int damage)
    {
        GameObject damageNumberObj = Instantiate(
            damageNumberPrefab,
            transform.position,
            Quaternion.identity
        );
        DamageNumber damageNumber = damageNumberObj.GetComponent<DamageNumber>();
        damageNumber.SetDamageNumber(damage);
        damageNumber.SetColor(damageNumberColor);
        currentHealth = Math.Max(currentHealth-damage,0);
        healthbar.SetHealth(currentHealth);

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
        Destroy(healthbar.gameObject,1f);
    }
}
