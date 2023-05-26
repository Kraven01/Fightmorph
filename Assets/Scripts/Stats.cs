using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Stats : MonoBehaviour
{
    protected int level { get; set; }
    protected int strength { get; set; }
    protected int dexterity { get; set; }
    protected int vitality { get; set; }
    protected int stamina { get; set; }

    public virtual void Start()
    {
        this.level = 0;
        this.strength = 0;
        this.dexterity = 0;
        this.vitality = 0;
        this.stamina = 0;
    }

    public virtual void DeployEqually()
    {
        int totalPoints = level -(strength + dexterity + vitality + stamina);

        while (totalPoints > 0)
        {
            if (strength < level && totalPoints > 0)
            {
                strength++;
                totalPoints--;
            }

            if (dexterity < level && totalPoints > 0)
            {
                dexterity++;
                totalPoints--;
            }

            if (vitality < level && totalPoints > 0)
            {
                vitality++;
                totalPoints--;
            }

            if (stamina < level && totalPoints > 0)
            {
                stamina++;
                totalPoints--;
            }
        }
    }
}
