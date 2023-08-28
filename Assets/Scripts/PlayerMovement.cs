using UnityEngine;

public class PlayerMovement : Movement
{
    private GameObject characterMenu;
    private PlayerStats playerStats;

    private StatSelecter statSelecter;

    // Start is called before the first frame update
    private void Start()
    {
        this.rotationValue = 0f;
        this.flip = 0f;
        this.characterMenu = GameObject.Find("CharacterMenu");
        this.playerStats = this.GetComponent<PlayerStats>();
        this.statSelecter = this.characterMenu.GetComponent<StatSelecter>();
        this.statSelecter.Deactivate();
    }

    // Update is called once per frame
    public override void Update()
    {
        if (!this.dead)
        {
            this.movement.x = Input.GetAxisRaw("Horizontal");

            this.movement.y = Input.GetAxisRaw("Vertical");


            if (Input.GetKeyDown(KeyCode.C))
            {
                if (!this.statSelecter.visible)
                {
                    this.statSelecter.Activate();
                }
                else
                {
                    this.statSelecter.Deactivate();
                }
            }

            base.Update();
        }
    }

    public override void FixedUpdate()
    {
        if (this.movement.x > 0)
        {
            this.GetComponent<Combat>().right = true;
            this.animator.SetBool("right", true);
        }
        else if (this.movement.x < 0)
        {
            this.GetComponent<Combat>().right = false;
            this.animator.SetBool("right", false);
        }

        base.FixedUpdate();
    }

    public void SyncStats()
    {
        Debug.Log(this.playerStats);
        Debug.Log(this.playerStats.dexterity);
        this.moveSpeed = 5f + this.playerStats.dexterity;
    }
}