using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHealth
{
    void takeDamage(int damage);
    void heal(int amount);
    void die();
} 
