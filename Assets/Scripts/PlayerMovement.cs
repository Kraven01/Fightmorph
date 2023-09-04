using UnityEngine;

public class PlayerMovement : Movement
{
    private GameObject characterMenu;
    private GameController gameController;
    [SerializeField] private GameObject optionsMenu;
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
        this.gameController = this.GetComponent<GameController>();
        this.optionsMenu.SetActive(false);
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
                if (this.optionsMenu.activeSelf)
                {
                    return;
                }

                if (!this.statSelecter.visible)
                {
                    this.statSelecter.Activate();
                    this.gameController.TogglePause();
                }
                else
                {
                    this.statSelecter.Deactivate();
                    this.gameController.TogglePause();
                }
            }

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (!this.statSelecter.visible)
                {
                    this.optionsMenu.SetActive(!this.optionsMenu.activeSelf);
                    this.gameController.TogglePause();
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
        this.moveSpeed = 5f + this.playerStats.dexterity;
    }
}