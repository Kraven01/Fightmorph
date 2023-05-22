using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Movement : MonoBehaviour
{
    public float moveSpeed = 5f;

    public Rigidbody2D rb;
    public Animator animator;
    public Vector2 movement;
    public float rotationValue;
    public bool dead = false;
    public float flip;

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
        animator.SetFloat("speed", movement.sqrMagnitude);
    }

    public virtual void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
