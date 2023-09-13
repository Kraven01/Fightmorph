using System.Collections;
using UnityEngine;

public class KnightBossCombat : EnemyCombat
{
    public Transform FireballSpawner;
    public float spawnRadius = 5f;

    public override void Start()
    {
        base.Start();
    }

    public override void Update()
    {
        float distanceToPlayer = Vector3.Distance(this.transform.position, this.target.position);
        if (this.canAttack && !this.dead && distanceToPlayer <= this.attackTriggerRange)
        {
            this.GetComponent<AudioPlayer>().PlayAttackSound();
            this.StartCoroutine(this.Attack());
        }
    }

    public IEnumerator BossMechanic(int numberFireball, float secondsToWait)
    {
        BoxCollider2D bossHitbox = this.GetComponent<BoxCollider2D>();
        // Disable Hitbox
        bossHitbox.enabled = false;
        this.canAttack = false;

        // Move to center
        EnemyMovement bossMovement = this.GetComponent<EnemyMovement>();
        bossMovement.canMove = false;
        yield return this.StartCoroutine(bossMovement.MoveToPosition(this.FireballSpawner.position + Vector3.up));

        // Start fireball anim
        this.animator.SetTrigger("fireball");
        this.audioPlayer.PlayFireCastSound();
        yield return new WaitForSeconds(0.5f);
        // Spawn Fireballs
        this.StartCoroutine(this.SpawnFireballs(numberFireball));

        yield return new WaitForSeconds(secondsToWait);
        bossHitbox.enabled = true;
        bossMovement.canMove = true;
        this.canAttack = true;
        this.animator.SetTrigger("endMechanic");
    }

    private IEnumerator SpawnFireballs(int numberOfFireballs)
    {
        for (int i = 0; i < numberOfFireballs; i++)
        {
            float angle = i * (360f / numberOfFireballs);
            Vector3 spawnPosition = this.FireballSpawner.position +
                                    Quaternion.Euler(0, 0, angle) * (Vector3.right * this.spawnRadius);
            Vector2 direction = (this.FireballSpawner.position - spawnPosition).normalized;
            GameObject fireball = Instantiate(this.Fireball, spawnPosition, Quaternion.identity);
            fireball.GetComponent<FireBall>().direction = -direction;
            fireball.transform.localScale = 0.8f * this.transform.localScale;
            yield return new WaitForSeconds(0.075f);
        }
    }
}