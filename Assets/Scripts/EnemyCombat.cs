using UnityEngine;

public class EnemyCombat : Combat
{
    public int attackDamage = 3;
    protected float attackTriggerRange = 2f;

    protected Transform target;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        this.targetLayer = LayerMask.GetMask("Player");
        this.target = GameObject.Find("KnightPlayer").transform;
        this.cooldown = 2f;
        this.attackTriggerRange = Vector3.Distance(this.transform.position, this.attackPoint.position) + 1f;
    }

    // Update is called once per frame
    public override void Update()
    {
        float distanceToPlayer = Vector3.Distance(this.transform.position, this.target.position);
        if (this.canAttack && !this.dead && distanceToPlayer <= this.attackTriggerRange)
        {
            this.GetComponent<AudioPlayer>().PlayAttackSound();
            this.StartCoroutine(this.Attack());
        }
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Vector3 parentPosition = this.attackPoint.transform.position;
        Gizmos.DrawWireSphere(parentPosition + new Vector3(this.xRange, this.yRange, 0f), this.attackRange);
    }


    public override void dealDamage(Collider2D target)
    {
        PlayerHealth playerHealth = target.GetComponent<PlayerHealth>();
        playerHealth.takeDamage(this.attackDamage);
    }

    public override Collider2D[] computeTargets()
    {
        return Physics2D.OverlapCircleAll(this.attackPoint.position, this.attackRange, this.targetLayer);
    }
}