using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatSelecter : MonoBehaviour
{
    private int strengthLevel;
    private int dexLevel;
    private int vitalityLevel;
    private int staminaLevel;
    private int level;
    private int pointsToSpend;
    public TextMesh showPointsToSpend;
    public TextMesh showStrength;
    public TextMesh showDex;
    public TextMesh showVitality;
    public TextMesh showStamina;
    public TextMesh showLevel;
    public bool visible = true;
    PlayerStats playerstats;
    Canvas canvas;

    void Start()
    {
        playerstats = GameObject.Find("KnightPlayer").GetComponent<PlayerStats>();
        canvas = GetComponent<Canvas>();
    }

    public void Activate()
    {
        gameObject.SetActive(true);
        visible = true;
        syncStats();
    }

    public void Deactivate()
    {
        gameObject.SetActive(false);
        visible = false;
    }

    void syncStats()
    {
        strengthLevel = playerstats.strength;
        dexLevel = playerstats.dexterity;
        vitalityLevel = playerstats.vitality;
        staminaLevel = playerstats.stamina;
        level = playerstats.level;

        showPointsToSpend.text = (level -1 - (strengthLevel + dexLevel + vitalityLevel + staminaLevel)).ToString();
        showStrength.text = strengthLevel.ToString();
        showDex.text = dexLevel.ToString();
        showVitality.text = vitalityLevel.ToString();
        showStamina.text = staminaLevel.ToString();
        showLevel.text = level.ToString();
    }
}
