using System.Collections;
using UnityEngine;

public class KnightBossCombat : EnemyCombat
{
    private void SummonFireball()
    {
        this.StartCoroutine(this.ThrowFireball());
        this.audioPlayer.PlayFireCastSound();
    }

    public override void Update()
    {
        float distanceToPlayer = Vector3.Distance(this.transform.position, this.target.position);
        if (this.canAttack && !this.dead && distanceToPlayer >= this.attackTriggerRange &&
            distanceToPlayer <= this.attackTriggerRange * 10f)
        {
            this.SummonFireball();
        }

        if (this.canAttack && !this.dead && distanceToPlayer <= this.attackTriggerRange)
        {
            this.GetComponent<AudioPlayer>().PlayAttackSound();
            this.StartCoroutine(this.Attack());
        }
    }

    public override IEnumerator ThrowFireball()
    {
        this.canAttack = false;
        this.animator.SetTrigger("fireball");
        yield return new WaitForSeconds(0.5f);
        // Summon Fireball projectile
        GameObject summonFireball =
            Instantiate(this.Fireball, this.attackPoint.transform.position, Quaternion.identity);
        summonFireball.GetComponent<FireBall>().direction =
            (this.target.position - this.attackPoint.position).normalized;
        summonFireball.transform.localScale = this.transform.localScale;
        yield return new WaitForSeconds(this.cooldown);
        this.canAttack = true;
    }
}