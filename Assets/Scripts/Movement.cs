using UnityEngine;

public abstract class Movement : MonoBehaviour
{
    public Animator animator;
    public bool dead = false;
    public float flip;
    public Vector2 movement;
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public float rotationValue;

    private void Awake()
    {
        this.rb = this.GetComponent<Rigidbody2D>();
        this.animator = this.GetComponent<Animator>();
    }

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    public virtual void Update()
    {
        this.animator.SetFloat("speed", this.movement.sqrMagnitude);
    }

    public virtual void FixedUpdate()
    {
        this.rb.MovePosition(this.rb.position + this.movement * this.moveSpeed * Time.fixedDeltaTime);
    }
}