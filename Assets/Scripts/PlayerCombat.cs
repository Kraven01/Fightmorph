using UnityEngine;

public class PlayerCombat : Combat
{
    public int attackDamage;
    public int baseAttackDamage = 6;
    public PlayerStats playerStats;

    public override void Start()
    {
        base.Start();
        this.targetLayer = LayerMask.GetMask("Enemies");
        this.cooldown = 1f;
        this.attackDamage = this.baseAttackDamage;
        this.playerStats = this.GetComponent<PlayerStats>();
    }

    // Update is called once per frame
    public override void Update()
    {
        if (this.canAttack && (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)))
        {
            this.GetComponent<AudioPlayer>().PlayAttackSound();
            this.StartCoroutine(this.Attack());
            return;
        }

        if (this.canAttack && Input.GetKeyDown(KeyCode.F))
        {
            this.GetComponent<AudioPlayer>().PlayFireCastSound();
            this.StartCoroutine(this.ThrowFireball());
        }
    }

    public override void dealDamage(Collider2D target)
    {
        if (target.gameObject.CompareTag("Projectile"))
        {
            Destroy(target.gameObject);
            return;
        }

        EnemyHealth enemyHealth = target.GetComponent<EnemyHealth>();
        if (enemyHealth == null)
        {
            enemyHealth = target.GetComponentInParent<EnemyHealth>();
        }

        enemyHealth.takeDamage(this.attackDamage);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Vector3 parentPosition = this.attackPoint.parent.position;
        Gizmos.DrawWireSphere(parentPosition + new Vector3(this.xRange, this.yRange, 0f), this.attackRange);
    }

    public override Collider2D[] computeTargets()
    {
        if (this.right)
        {
            Vector3 parentPos = this.attackPoint.parent.position + new Vector3(this.xRange, this.yRange, 0f);
            this.attackPoint.position = parentPos;
            return Physics2D.OverlapCircleAll(this.attackPoint.position, this.attackRange, this.targetLayer);
        }
        else
        {
            Vector3 parentPos = this.attackPoint.parent.position + new Vector3(-this.xRange, this.yRange, 0f);
            this.attackPoint.position = parentPos;
            return Physics2D.OverlapCircleAll(this.attackPoint.position, this.attackRange, this.targetLayer);
        }
    }

    public void SyncStats()
    {
        this.attackDamage = this.baseAttackDamage + this.playerStats.strength;
    }
}