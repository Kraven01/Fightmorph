using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : Stats
{
    public int currentXP;
    public TextMesh levelText;
    private readonly int[] toLevelUp = new int[20];
    private int XPNeeded;
    public Slider xpSlider;
    public TextMesh xpText;

    public override void Start()
    {
        base.Start();
        this.level = 1;
        this.currentXP = 0;
        this.maxLevel = this.toLevelUp.Length;
        this.LevelXPSetUp();
        this.XPNeeded = this.toLevelUp[this.level];
    }

    // Update is called once per frame
    private void Update()
    {
    }

    private void FixedUpdate()
    {
        float progress = (float)this.currentXP / this.XPNeeded;
        this.xpSlider.value = progress;
        this.xpText.text = string.Format("{0}/{1}", this.currentXP, this.XPNeeded);
        this.levelText.text = this.level.ToString();
    }

    public IEnumerator AddExperience(int experienceToAdd)
    {
        //received from external sources. Add xp incrementally to move bar up slowly instead of chunks.
        for (int i = 0; i < experienceToAdd; i++)
        {
            this.currentXP++;
            if (this.currentXP == this.XPNeeded)
            {
                this.LevelUp();
            }

            yield return new WaitForSeconds(.002f);
        }
    }

    private void LevelUp()
    {
        this.currentXP = 0;
        this.level += 1;
        this.XPNeeded = this.toLevelUp[this.level];
        this.GetComponent<PlayerHealth>().LevelUp();
    }

    private void LevelXPSetUp()
    {
        for (int i = 1; i < this.toLevelUp.Length; i++)
        {
            this.toLevelUp[i] = (int)Mathf.Floor(3 * Mathf.Pow(i, 1.5f));
        }
    }
}