using System.Collections;
using UnityEngine;

public class EnemyShooting : Combat
{
    public GameObject bullet;
    public Transform bulletPos;
    [SerializeField] private Animator chargeAnimator;
    private GameObject player;

    private bool shot;

    private float timer;

    // Start is called before the first frame update
    public override void Start()
    {
        this.player = GameObject.FindGameObjectWithTag("Player");
        this.canAttack = true;
    }

    // Update is called once per frame
    public override void Update()
    {
        if (this.dead || !this.canAttack)
        {
            return;
        }

        // TODO: Charge Up
        float distance = Vector2.Distance(this.transform.position, this.player.transform.position);

        if (distance < 10)
        {
            this.chargeAnimator.SetFloat("charging", 1f);
            this.timer += Time.deltaTime;
            if (!this.shot)
            {
                this.shoot();
                this.shot = true;
            }

            if (this.timer > 3)
            {
                this.timer = 0;
                this.chargeAnimator.SetFloat("charging", 0f);
                this.shoot();
                this.StartCoroutine(this.InitiateCooldown());
            }
        }
        else
        {
            this.timer = 0;
            this.chargeAnimator.SetFloat("charging", 0f);
        }
    }

    private IEnumerator InitiateCooldown()
    {
        this.canAttack = false;
        yield return new WaitForSeconds(2f);
        this.canAttack = true;
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