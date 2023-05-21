using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : Movement
{
    // Start is called before the first frame update
    void Start() { 
        rotationValue = 0f;
        flip = 0f;
    }

    // Update is called once per frame
    public override void Update()
    {
        if (!dead)
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");

            base.Update();
        }
    }
    public override void FixedUpdate()
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
        base.FixedUpdate();
        
    }
}
