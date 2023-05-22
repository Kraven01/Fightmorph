using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : Health
{ 
    public override void Awake()
    {
        maxHealth = 10;
        damageNumberColor = Color.red;
        base.Awake();
    }

    
}
