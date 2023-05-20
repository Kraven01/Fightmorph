using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : Movement
{
    Transform target;
    Transform currentObject;

    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("KnightPlayer").transform;
        currentObject = GetComponent<Transform>();
        moveSpeed = 2f;
    }

    // Update is called once per frame
    public override void Update()
    {
        if (target && !dead)
        {
            Vector3 direction = (target.position - currentObject.position).normalized;
            movement = direction;
            base.Update();
        }
    }

    public override void FixedUpdate()
    {
        if (target)
        {
            //rb.velocity = movement* moveSpeed;
            base.FixedUpdate();
        }
    }
}
