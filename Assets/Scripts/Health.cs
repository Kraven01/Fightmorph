using System;
using UnityEngine;

public abstract class Health : MonoBehaviour, IHealth
{
    public Animator animator;
    public int baseHealth;
    protected BoxCollider2D boxCollider;
    protected int currentHealth;
    public Color damageNumberColor;

    public GameObject damageNumberPrefab;
    public HealthBar Healthbar;
    public int maxHealth;

    public virtual void takeDamage(int damage)
    {
        GameObject damageNumberObj = Instantiate(this.damageNumberPrefab, this.transform.position,
            Quaternion.identity
        );
        DamageNumber damageNumber = damageNumberObj.GetComponent<DamageNumber>();
        damageNumber.SetDamageNumber(damage);
        damageNumber.SetColor(this.damageNumberColor);
        this.currentHealth = Math.Max(this.currentHealth - damage, 0);
        this.Healthbar?.SetHealth(this.currentHealth);
        if (this.currentHealth <= 0)
        {
            this.die();
        }
        else
        {
            this.animator.SetTrigger("hurt");
        }
    }

    public virtual void heal(int amount)
    {
        this.currentHealth += amount;
    }

    public virtual void die()
    {
        this.animator.SetTrigger("death");
        this.GetComponent<Movement>().dead = true;
        this.GetComponent<Combat>().dead = true;
        this.GetComponent<Movement>().movement = new Vector2(0f, 0f);
        this.boxCollider.enabled = false;
        Destroy(this.boxCollider?.gameObject, 10f);
        Destroy(this.Healthbar.gameObject, 1f);
    }

    public virtual void Awake()
    {
        this.currentHealth = this.maxHealth;
        this.animator = this.GetComponent<Animator>();
        this.boxCollider = this.GetComponent<BoxCollider2D>();
        if (this.Healthbar == null)
        {
            this.Healthbar = this.GetComponentInChildren<HealthBar>();
        }

        this.Healthbar.SetMaxHealth(this.maxHealth);
    }
}