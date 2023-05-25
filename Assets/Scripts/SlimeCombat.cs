using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeCombat : EnemyCombat
{
    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        attackRange = 0.65f;
        xRange = 0.5f;
        yRange = 0f;
    }
}
