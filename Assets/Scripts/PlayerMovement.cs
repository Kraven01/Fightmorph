using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : Movement
{
    GameObject characterMenu;
    StatSelecter statSelecter;
    PlayerStats playerStats;
    public bool canMove = true;
    // Start is called before the first frame update
    void Start() { 
        rotationValue = 0f;
        flip = 0f;
        characterMenu = GameObject.Find("CharacterMenu");
        playerStats = GetComponent<PlayerStats>();
        statSelecter = characterMenu.GetComponent<StatSelecter>();
        statSelecter.Deactivate();
    }

    // Update is called once per frame
    public override void Update()
    {

        if (!dead)
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            if (canMove)
            {
            movement.y = Input.GetAxisRaw("Vertical");
            }

            if(Input.GetKeyDown(KeyCode.C))
        {
            if(!statSelecter.visible)
            {
                statSelecter.Activate();
            }
            else 
            {
                statSelecter.Deactivate();
            }
        }

            base.Update();
        }
    }
    public override void FixedUpdate()
    {
    
        if (movement.x > 0)
        {
            GetComponent<Combat>().right = true;
            animator.SetBool("right",  true);
        } 
        else if (movement.x < 0)
        {
            GetComponent<Combat>().right = false;
            animator.SetBool("right",  false);
        }
        base.FixedUpdate();
    }

    public void SyncStats()
    {
        Debug.Log(playerStats);
        Debug.Log(playerStats.dexterity);
        moveSpeed = 5f + playerStats.dexterity;
    }
}
