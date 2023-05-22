using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : Health
{
    public override void Awake()
    {
        maxHealth = 15;
        damageNumberColor = Color.white;
        base.Awake();
    }
    
}
