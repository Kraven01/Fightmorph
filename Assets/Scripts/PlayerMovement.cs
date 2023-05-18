using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed = 5f;

    public Rigidbody2D rb;
    public Animator animator;

    Vector2 movement;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("movement_X", movement.x);
        animator.SetFloat("movement_Y", movement.y);
        animator.SetFloat("speed", movement.sqrMagnitude);

    }

    void FixedUpdate()
    {
        if (movement.x == 1)
        {
            GetComponent<PlayerCombat>().right = true;
        }
        else if (movement.x == -1)
        {
            GetComponent<PlayerCombat>().right = false;
        }
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
