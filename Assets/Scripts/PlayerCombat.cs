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
        this.attackRange = 0.5f;
        this.xRange = 1.2f;
        this.yRange = -0.5f;
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
        }
    }

    public override void dealDamage(Collider2D target)
    {
        EnemyHealth enemyHealth = target.GetComponent<EnemyHealth>();
        enemyHealth.takeDamage(this.attackDamage);
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