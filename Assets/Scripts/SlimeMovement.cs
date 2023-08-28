public class SlimeMovement : EnemyMovement
{
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        this.flip = 180f;
        this.viewRange = 5f;
    }
}