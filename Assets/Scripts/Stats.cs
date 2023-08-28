using UnityEngine;

public abstract class Stats : MonoBehaviour
{
    public int level { get; set; }
    public int strength { get; set; }
    public int dexterity { get; set; }
    public int vitality { get; set; }
    public int stamina { get; set; }
    protected int maxLevel { get; set; }

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
        int totalPoints = this.level - (this.strength + this.dexterity + this.vitality + this.stamina);

        while (totalPoints > 0)
        {
            if (this.strength < this.level && totalPoints > 0)
            {
                this.strength++;
                totalPoints--;
            }

            if (this.dexterity < this.level && totalPoints > 0)
            {
                this.dexterity++;
                totalPoints--;
            }

            if (this.vitality < this.level && totalPoints > 0)
            {
                this.vitality++;
                totalPoints--;
            }

            if (this.stamina < this.level && totalPoints > 0)
            {
                this.stamina++;
                totalPoints--;
            }
        }
    }
}