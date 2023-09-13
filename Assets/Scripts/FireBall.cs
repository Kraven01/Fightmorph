using UnityEngine;

public class FireBall : MonoBehaviour
{
    private const int spellDamage = 5;
    private readonly float fireBallSpeed = 6f;
    private Animator animator;
    private AudioPlayer audioPlayer;
    private AudioSource audioSource;
    public Vector2 direction;
    private Vector3 initialPosition;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    private void Start()
    {
        this.rb = this.GetComponent<Rigidbody2D>();
        this.animator = this.GetComponent<Animator>();
        this.audioSource = this.GetComponent<AudioSource>();
        this.audioPlayer = this.GetComponent<AudioPlayer>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        this.rb.velocity = this.direction * this.fireBallSpeed;
        float angle = Mathf.Atan2(this.direction.y, this.direction.x) * Mathf.Rad2Deg;
        this.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Projectile"))
        {
            return;
        }

        this.audioPlayer.PlayExplosionSound();
        this.direction = Vector2.zero;
        this.animator.SetTrigger("hit");
        if (other.CompareTag("Enemy"))
        {
            other.gameObject.GetComponentInChildren<EnemyHealth>().takeDamage(spellDamage);
        }

        if (other.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerHealth>().takeDamage(spellDamage);
        }

        Destroy(this.gameObject.GetComponent<BoxCollider2D>());
        Destroy(this.gameObject, 1f);
    }
}