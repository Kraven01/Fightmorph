using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : Stats
{
    private int XPNeeded;
    public int currentXP;
    private int[] toLevelUp = new int[20];
    public Slider xpSlider;
    public TextMesh xpText;
    public TextMesh levelText;

    public override void Start()
    {
        base.Start();
        level = 1;
        currentXP = 0;
        maxLevel = toLevelUp.Length;
        LevelXPSetUp();
        XPNeeded = toLevelUp[level];
    }

    // Update is called once per frame
    void Update() { }

    void FixedUpdate()
    {
        float progress = (float) currentXP/XPNeeded;
        xpSlider.value = progress;
        xpText.text = string.Format("{0}/{1}", currentXP, XPNeeded);
        levelText.text = level.ToString();
    }

    public IEnumerator AddExperience(int experienceToAdd)
    {
        //received from external sources. Add xp incrementally to move bar up slowly instead of chunks.
        for (int i = 0; i < experienceToAdd; i++)
        {
            currentXP++;
            if(currentXP == XPNeeded)
            {
                    LevelUp();
            }
            yield return new WaitForSeconds(.002f);
        }
    }

    void LevelUp()
    {
        currentXP = 0;
        level +=1;
        XPNeeded = toLevelUp[level];
        GetComponent<PlayerHealth>().LevelUp();
    }

    void LevelXPSetUp()
    {
        for (int i = 1; i < toLevelUp.Length; i++)
        {
            toLevelUp[i] = (int)(Mathf.Floor(3 * (Mathf.Pow(i, 1.5f))));
        }
    }
}
