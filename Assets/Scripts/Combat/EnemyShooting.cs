using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletPos;
    private GameObject player;

    private bool shot;

    private float timer;

    // Start is called before the first frame update
    private void Start()
    {
        this.player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    private void Update()
    {
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

    private void shoot()
    {
        Instantiate(this.bullet, this.bulletPos.position, Quaternion.identity);
    }
}