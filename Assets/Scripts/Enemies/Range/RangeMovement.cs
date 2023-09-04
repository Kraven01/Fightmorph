public class RangeMovement : EnemyMovement
{
    public override void Start()
    {
        base.Start();
        this.viewRange = 15f;
        this.moveSpeed = 0.25f;
        this.inverse = -1;
    }

    // Update is called once per frame
    public override void Update()
    {
        base.Update();
    }
}