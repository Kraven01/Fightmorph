using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : Movement
{
    // Start is called before the first frame update
    void Start() { }

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
        if (movement.x == 1)
        {
            GetComponent<PlayerCombat>().right = true;
        }
        else if (movement.x == -1)
        {
            GetComponent<PlayerCombat>().right = false;
        }
        base.FixedUpdate();
    }
}
