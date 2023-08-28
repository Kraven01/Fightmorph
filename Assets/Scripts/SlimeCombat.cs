public class SlimeCombat : EnemyCombat
{
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        this.attackRange = 0.65f;
        this.xRange = 0.5f;
        this.yRange = 0f;
    }
}