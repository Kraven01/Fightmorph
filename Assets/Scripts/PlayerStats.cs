using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : Stats
{
    private int XPNeeded;
    private int currentXP;
    private int[] toLevelUp = new int[10];
    public override void Start()
    {
        base.Start();
        level = 10;
        DeployEqually();
        LevelXPSetUp();
        for(int i = 0; i<toLevelUp.Length;i++)
        {
            Debug.Log(toLevelUp[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CalculateXp()
    {

    }

    void LevelXPSetUp(){
         for (int i = 1; i < toLevelUp.Length; i++) {
             toLevelUp[i] = (int)(Mathf.Floor(10*(Mathf.Pow(i,1.5f))));
         }
    }
}
