using UnityEngine;

public class EnemyBulletScript : Combat
{
    private const int attackDamage = 3;
    private readonly float growthSpeed = 2f;
    private readonly float maxScale = 2f;
    private float bulletTimer;
    private Vector3 direction;

    private bool hitWall;
    private Vector3 initialPosition;
    private Vector3 initialScale;
    private GameObject player;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    public override void Start()
    {
        this.rb = this.GetComponent<Rigidbody2D>();
        this.player = GameObject.FindGameObjectWithTag("Player");

        this.initialPosition = this.transform.position;
        this.initialScale = this.transform.localScale;
        this.direction = this.player.transform.position - this.initialPosition; // Calculate direction only once
        this.bulletTimer = 0;
    }

    public override void Update()
    {
        this.bulletTimer += Time.deltaTime;

        if (this.bulletTimer > 2f)
        {
            Destroy(this.gameObject);
        }

        if (this.hitWall)
        {
            return;
        }


        if (this.bulletTimer < 0.3f)
        {
            // Calculate rotation to follow player during the first 0.3 seconds
            float rot = Mathf.Atan2(this.direction.y, this.direction.x) * Mathf.Rad2Deg;
            this.transform.rotation = Quaternion.Euler(0, 0, rot);
        }


        // Calculate the new scale based on growth speed
        float newScaleX = Mathf.Min(this.transform.localScale.x + this.growthSpeed * Time.deltaTime, this.maxScale);
        Vector3 newScale = new(newScaleX, this.initialScale.y, this.initialScale.z);

        this.transform.localScale = newScale;

        // Update the position to keep the origin fixed
        Vector3 newPosition =
            this.initialPosition + this.direction.normalized * (newScaleX - this.initialScale.x) * 2.3f;
        this.transform.position = newPosition;
    }

    public override void dealDamage(Collider2D target)
    {
        PlayerHealth playerHealth = target.GetComponent<PlayerHealth>();
        playerHealth.takeDamage(attackDamage);
    }

    public override Collider2D[] computeTargets()
    {
        return null;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            this.dealDamage(other);
            return;
        }

        if (other.gameObject.CompareTag("Obstacles"))
        {
            this.hitWall = true;
        }
    }
}