using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeMovement : EnemyMovement
{
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        flip = 180f;
        viewRange= 5f;
    }

    
}
