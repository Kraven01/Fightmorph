using UnityEngine;

public class EnemyCombat : Combat
{
    public int attackDamage = 3;
    private readonly float attackTriggerRange = 2f;

    private Transform target;

    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        this.attackRange = 0.5f;
        this.targetLayer = LayerMask.GetMask("Player");
        this.target = GameObject.Find("KnightPlayer").transform;
        this.cooldown = 2f;
        this.xRange = 1.2f;
        this.yRange = -0.5f;
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