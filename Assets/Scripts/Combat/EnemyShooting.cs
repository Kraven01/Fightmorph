using UnityEngine;

public class EnemyShooting : Combat
{
    public GameObject bullet;
    public Transform bulletPos;
    private GameObject player;

    private bool shot;

    private float timer;

    // Start is called before the first frame update
    public override void Start()
    {
        this.player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    public override void Update()
    {
        if (this.dead)
        {
            return;
        }

        // TODO: Charge Up
        float distance = Vector2.Distance(this.transform.position, this.player.transform.position);

        if (distance < 10)
        {
            this.timer += Time.deltaTime;
            if (!this.shot)
            {
                this.shoot();
                this.shot = true;
            }

            if (this.timer > 5)
            {
                this.timer = 0;
                this.shoot();
            }
        }
    }

    public override void dealDamage(Collider2D target)
    {
    }

    public override Collider2D[] computeTargets()
    {
        return null;
    }

    private void shoot()
    {
        Instantiate(this.bullet, this.bulletPos.position, Quaternion.identity);
    }
}