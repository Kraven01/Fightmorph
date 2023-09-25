using UnityEngine;

public class SlimeBossCombat : EnemyCombat
{
    public override void Start()
    {
        base.Start();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Vector3 parentPosition = this.attackPoint.transform.position;
        Gizmos.DrawWireSphere(parentPosition + new Vector3(this.xRange, this.yRange, 0f), this.attackRange);
    }
}