using UnityEngine;

public class EnemyBulletScript : MonoBehaviour
{
    private readonly float growthSpeed = 2f;
    private readonly float maxScale = 2f;
    private float bulletTimer;
    private Vector3 direction;
    private Vector3 initialPosition;
    private Vector3 initialScale;

    private GameObject player;
    private Rigidbody2D rb;


    // Start is called before the first frame update
    private void Start()
    {
        this.rb = this.GetComponent<Rigidbody2D>();
        this.player = GameObject.FindGameObjectWithTag("Player");

        this.initialScale = this.transform.localScale;
        this.initialPosition = this.transform.position;
        this.bulletTimer = 0;
    }

    // Update is called once per frame
    private void Update()
    {
        this.bulletTimer += Time.deltaTime;
        float newScaleX = Mathf.Min(this.transform.localScale.x + this.growthSpeed * Time.deltaTime, this.maxScale);
        Vector3 newScale = new(newScaleX, this.initialScale.y, this.initialScale.z);

        this.transform.localScale = newScale;


        if (this.bulletTimer < 0.3f)
        {
            this.direction = this.player.transform.position - this.initialPosition;
            float rot = Mathf.Atan2(this.direction.y, this.direction.x) * Mathf.Rad2Deg;
            this.transform.rotation = Quaternion.Euler(0, 0, rot);
        }

        Vector3 newPosition =
            this.initialPosition + this.direction.normalized * (newScaleX - this.initialScale.x) * 2.3f;
        this.transform.position = newPosition;

        if (this.bulletTimer > 2f)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("collision with" + other.gameObject.name);
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(this.gameObject);
        }
    }
}