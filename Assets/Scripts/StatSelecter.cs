using UnityEngine;
using UnityEngine.UI;

public class StatSelecter : MonoBehaviour
{
    private readonly Color HighlightColor = Color.red;
    private Canvas canvas;
    private int dexLevel;

    [SerializeField] private GameObject[] images;

    private int level;
    private PlayerStats playerstats;
    private int pointsToSpend;
    private int selectedIndex;
    public TextMesh showDex;
    public TextMesh showLevel;
    public TextMesh showPointsToSpend;
    public TextMesh showStamina;
    public TextMesh showStrength;
    public TextMesh showVitality;
    private int staminaLevel;
    private int strengthLevel;
    public bool visible = true;
    private int vitalityLevel;

    private void Start()
    {
        this.playerstats = GameObject.Find("KnightPlayer").GetComponent<PlayerStats>();
        this.canvas = this.GetComponent<Canvas>();
    }

    public void Activate()
    {
        this.gameObject.SetActive(true);
        this.visible = true;
        this.syncStats();
    }

    public void Deactivate()
    {
        this.gameObject.SetActive(false);


        this.visible = false;
    }

    public void syncStats()
    {
        this.strengthLevel = this.playerstats.strength;
        this.dexLevel = this.playerstats.dexterity;
        this.vitalityLevel = this.playerstats.vitality;
        this.staminaLevel = this.playerstats.stamina;
        this.level = this.playerstats.level;
        this.pointsToSpend =
            this.level - 1 - (this.strengthLevel + this.dexLevel + this.vitalityLevel + this.staminaLevel);

        this.showPointsToSpend.text =
            (this.level - 1 - (this.strengthLevel + this.dexLevel + this.vitalityLevel + this.staminaLevel)
            ).ToString();
        this.showStrength.text = this.strengthLevel.ToString();
        this.showDex.text = this.dexLevel.ToString();
        this.showVitality.text = this.vitalityLevel.ToString();
        this.showStamina.text = this.staminaLevel.ToString();
        this.showLevel.text = this.level.ToString();

        GameObject.Find("KnightPlayer").GetComponent<PlayerCombat>().SyncStats();
        GameObject.Find("KnightPlayer").GetComponent<PlayerHealth>().SyncStats();
        GameObject.Find("KnightPlayer").GetComponent<PlayerMovement>().SyncStats();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.GetRayIntersection(ray);

            if (hit.collider != null)
            {
                for (int i = 0; i < this.images.Length; i++)
                {
                    if (hit.collider.gameObject == this.images[i])
                    {
                        this.selectedIndex = i;
                        this.HighlightSelectedImage();
                        this.HandleConfirmationEvent();
                        break;
                    }
                }
            }
        }
    }

    private void HandleConfirmationEvent()
    {
        this.images[this.selectedIndex].GetComponent<Image>().color = Color.white;
        if (this.selectedIndex == 0)
        {
            this.Deactivate();
        }
        else
        {
            this.increaseStat();
        }
    }

    private void increaseStat()
    {
        if (this.pointsToSpend > 0)
        {
            switch (this.selectedIndex)
            {
                case 1:
                    this.playerstats.strength += 1;
                    break;
                case 2:
                    this.playerstats.dexterity += 1;
                    break;
                case 3:
                    this.playerstats.vitality += 1;
                    break;
                case 4:
                    this.playerstats.stamina += 1;
                    break;
            }

            this.pointsToSpend -= 1;
            this.syncStats();
        }
    }

    public void HighlightSelectedImage()
    {
        for (int i = 0; i < this.images.Length; i++)
        {
            Image highlightImage = this.images[i].GetComponent<Image>();
            if (i == this.selectedIndex)
            {
                highlightImage.color = this.HighlightColor;
            }
            else
            {
                highlightImage.color = Color.white;
            }
        }
    }
}