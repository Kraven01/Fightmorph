using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Movement : MonoBehaviour
{
    public float moveSpeed = 5f;

    public Rigidbody2D rb;
    public Animator animator;
    public Vector2 movement;
    public bool dead = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Start is called before the first frame update
    void Start() { }

    // Update is called once per frame
    public virtual void Update()
    {
        //animator.SetFloat("movement_X", movement.x);
        //animator.SetFloat("movement_Y", movement.y);
        animator.SetFloat("speed", movement.sqrMagnitude);
    }

    public virtual void FixedUpdate()
    {
         if (movement.x > 0)
        {
            GetComponent<Combat>().right = true;
            animator.SetBool("right",  true);
        }
        else if (movement.x < 0)
        {
            GetComponent<Combat>().right = false;
            animator.SetBool("right",  false);
        }
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
