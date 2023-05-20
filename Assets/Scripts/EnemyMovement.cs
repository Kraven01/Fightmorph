using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : Movement
{
    Transform target;
    Transform currentObject;
    public float viewRange = 3f;

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
        float distanceToPlayer = Vector3.Distance(transform.position, target.position);
        if (target && !dead && distanceToPlayer <=viewRange)
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
