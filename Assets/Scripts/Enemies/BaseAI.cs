using System.Collections;
using Pathfinding;
using UnityEngine;

public class BaseAI : MonoBehaviour
{
    private bool canMove = true;
    private int currentWaypoint;

    public float moveSpeed = 2f;

    public float nextWaypointDistance = 3f;

    private Path path;

    private Rigidbody2D rb;

    private bool reachedEdnOfPath;

    private Seeker seeker;

    public Transform target;

    // Start is called before the first frame update
    private void Start()
    {
        this.seeker = this.GetComponent<Seeker>();
        this.rb = this.GetComponent<Rigidbody2D>();

        this.InvokeRepeating("UpdatePath", 0f, 1f);
    }

    private void UpdatePath()
    {
        if (this.seeker.IsDone() && this.canMove)
        {
            this.seeker.StartPath(this.rb.position, this.target.position, this.OnPathComplete);
        }
    }

    private void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            this.path = p;
            this.currentWaypoint = 0;
        }
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (this.path == null)
        {
            return;
        }

        if (this.currentWaypoint >= this.path.vectorPath.Count)
        {
            this.reachedEdnOfPath = true;
            return;
        }

        this.reachedEdnOfPath = false;

        Vector2 direction = ((Vector2)this.path.vectorPath[this.currentWaypoint] - this.rb.position).normalized;
        Vector2 force = direction * this.moveSpeed * Time.deltaTime;

        RaycastHit2D hit = Physics2D.Raycast(this.rb.position, direction, 2f);


        this.rb.AddForce(force);

        float distance = Vector2.Distance(this.rb.position, this.path.vectorPath[this.currentWaypoint]);

        if (distance < this.nextWaypointDistance)
        {
            this.currentWaypoint++;
        }
    }

    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision 0");
        this.canMove = false;
        if (collision.transform.tag != "Obstacles")
        {
            return;
        }

        this.StartCoroutine(this.CalculateAdjustedTarget());
    }*/

    private IEnumerator CalculateAdjustedTarget()
    {
        Vector2 direction = ((Vector2)this.path.vectorPath[this.currentWaypoint] - this.rb.position).normalized;
        Vector2 force = -direction * this.moveSpeed * Time.deltaTime;
        this.rb.AddForce(force);

        yield return new WaitForSeconds(2f);
        this.canMove = true;
    }
}