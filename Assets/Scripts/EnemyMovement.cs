using UnityEngine;

public class EnemyMovement : Movement
{
    private Transform currentObject;
    public RectTransform healthbarRectTransform;

    public Transform healthbarTransform;
    protected float inverse = 1;
    private Transform target;
    public float viewRange;

    // Start is called before the first frame update
    public virtual void Start()
    {
        this.target = GameObject.Find("KnightPlayer").transform;
        this.currentObject = this.GetComponent<Transform>();
        this.healthbarTransform = this.currentObject.Find("EnemyHealth");
        this.healthbarRectTransform = this.healthbarTransform.GetComponent<RectTransform>();
        this.moveSpeed = 2f;
        this.rotationValue = 180f;
        this.flip = 0f;
        this.viewRange = 7f;
    }

    // Update is called once per frame
    public override void Update()
    {
        float distanceToPlayer = Vector3.Distance(this.transform.position, this.target.position);
        if (this.target && !this.dead && distanceToPlayer <= this.viewRange)
        {
            Vector3 direction = this.inverse * (this.target.position - this.currentObject.position).normalized;
            this.movement = direction;
            base.Update();
        }
        else if (distanceToPlayer > this.viewRange)
        {
            this.animator.SetFloat("speed", 0);
            this.movement = new Vector2(0f, 0f);
        }
    }

    public override void FixedUpdate()
    {
        if (this.target)
        {
            if (this.movement.x > 0)
            {
                this.transform.rotation = Quaternion.Euler(0f, 0f + this.flip, 0f);
                this.healthbarRectTransform.rotation = Quaternion.identity;
            }
            else if (this.movement.x < 0)
            {
                this.transform.rotation = Quaternion.Euler(0f, this.rotationValue + this.flip, 0f);
                this.healthbarRectTransform.rotation = Quaternion.identity;
            }

            base.FixedUpdate();
        }
    }
}