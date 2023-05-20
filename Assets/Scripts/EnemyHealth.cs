using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : Health
{
    public override void takeDamage(int damage)
    {
        GameObject damageNumberObj = Instantiate(
            damageNumberPrefab,
            transform.position,
            Quaternion.identity
        );
        DamageNumber damageNumber = damageNumberObj.GetComponent<DamageNumber>();
        damageNumber.SetDamageNumber(damage);
        damageNumber.SetColor(Color.white);
        base.takeDamage(damage);
    }
}
