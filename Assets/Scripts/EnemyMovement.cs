using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : Movement
{
    Transform target;
    Transform currentObject;
    public float viewRange = 15f;

    public Transform healthbarTransform;
    public RectTransform healthbarRectTransform;

    // Start is called before the first frame update
    public virtual void Start()
    {
        target = GameObject.Find("KnightPlayer").transform;
        currentObject = GetComponent<Transform>();
        healthbarTransform = currentObject.Find("EnemyHealth");
        healthbarRectTransform = healthbarTransform.GetComponent<RectTransform>();
        moveSpeed = 2f;
        rotationValue = 180f;
        flip = 0f;
    }

    // Update is called once per frame
    public override void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, target.position);
        if (target && !dead && distanceToPlayer <= viewRange)
        {
            Vector3 direction = (target.position - currentObject.position).normalized;
            movement = direction;
            base.Update();
        }
        else if (distanceToPlayer > viewRange)
        {
            animator.SetFloat("speed", 0);
            movement = new Vector2(0f, 0f);
        }
    }

    public override void FixedUpdate()
    {
        if (target)
        {
            if (movement.x > 0)
            {
                transform.rotation = Quaternion.Euler(0f, 0f + flip, 0f);
                healthbarRectTransform.rotation = Quaternion.identity;

            }
            else if (movement.x < 0)
            {
                transform.rotation = Quaternion.Euler(0f, rotationValue + flip, 0f);
                healthbarRectTransform.rotation = Quaternion.identity;
            }
            base.FixedUpdate();
        }
    }
}
