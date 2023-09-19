using Pathfinding;
using UnityEngine;

public class TestMovement : MonoBehaviour
{
    private AIPath aiPath;

    private Seeker seeker;

    public Transform target;

    // Start is called before the first frame update
    private void Start()
    {
        this.seeker = this.GetComponent<Seeker>();
        this.aiPath = this.GetComponent<AIPath>();
        this.seeker.StartPath(this.transform.position, this.target.position);
    }
}