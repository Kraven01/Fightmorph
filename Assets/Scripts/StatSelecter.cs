using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

    Color HighlightColor = Color.red;

    [SerializeField]
    private GameObject[] images;
    private int selectedIndex = 0;

    void Start()
    {
        playerstats = GameObject.Find("KnightPlayer").GetComponent<PlayerStats>();
        canvas = GetComponent<Canvas>();
    }

    public void Activate()
    {
        gameObject.SetActive(true);
        visible = true;
        GameObject.Find("KnightPlayer").GetComponent<PlayerCombat>().canAttack = false;
        GameObject.Find("KnightPlayer").GetComponent<PlayerMovement>().canMove = false;
        syncStats();
    }

    public void Deactivate()
    {
        gameObject.SetActive(false);
        GameObject.Find("KnightPlayer").GetComponent<PlayerCombat>().canAttack = true;
        GameObject.Find("KnightPlayer").GetComponent<PlayerMovement>().canMove = true;
        GameObject.Find("KnightPlayer").GetComponent<PlayerCombat>().SyncStats();
        GameObject.Find("KnightPlayer").GetComponent<PlayerHealth>().SyncStats();
        GameObject.Find("KnightPlayer").GetComponent<PlayerMovement>().SyncStats();
        

        visible = false;
    }

    public void syncStats()
    {
        strengthLevel = playerstats.strength;
        dexLevel = playerstats.dexterity;
        vitalityLevel = playerstats.vitality;
        staminaLevel = playerstats.stamina;
        level = playerstats.level;
        pointsToSpend = level - 1 - (strengthLevel + dexLevel + vitalityLevel + staminaLevel);

        showPointsToSpend.text = (
            level - 1 - (strengthLevel + dexLevel + vitalityLevel + staminaLevel)
        ).ToString();
        showStrength.text = strengthLevel.ToString();
        showDex.text = dexLevel.ToString();
        showVitality.text = vitalityLevel.ToString();
        showStamina.text = staminaLevel.ToString();
        showLevel.text = level.ToString();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.GetRayIntersection(ray);

            if (hit.collider != null)
            {
                for (int i = 0; i < images.Length; i++)
                {
                    if (hit.collider.gameObject == images[i])
                    {
                        selectedIndex = i;
                        HighlightSelectedImage();
                        HandleConfirmationEvent();
                        break;
                    }
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            selectedIndex += Input.GetKeyDown(KeyCode.UpArrow) ? -1 : 1;

            if (selectedIndex < 0)
                selectedIndex = images.Length - 1;
            else if (selectedIndex >= images.Length)
                selectedIndex = 0;

            HighlightSelectedImage();
        }

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S))
        {
            selectedIndex += Input.GetKeyDown(KeyCode.W) ? -1 : 1;

            if (selectedIndex < 0)
                selectedIndex = images.Length - 1;
            else if (selectedIndex >= images.Length)
                selectedIndex = 0;

            HighlightSelectedImage();
        }

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return))
        {
            HandleConfirmationEvent();
        }
    }

    private void HandleConfirmationEvent()
    {
        images[selectedIndex].GetComponent<Image>().color = Color.white;
        if (selectedIndex == 0)
            Deactivate();
        else
            increaseStat();
    }

    void increaseStat()
    {
        if (pointsToSpend > 0)
        {
            switch (selectedIndex)
            {
                case 1:
                    playerstats.strength += 1;
                    break;
                case 2:
                    playerstats.dexterity += 1;
                    break;
                case 3:
                    playerstats.vitality += 1;
                    break;
                case 4:
                    playerstats.stamina += 1;
                    break;
            }
            pointsToSpend -=1;
            syncStats();
        }
    }

    public void HighlightSelectedImage()
    {
        for (int i = 0; i < images.Length; i++)
        {
            Image highlightImage = images[i].GetComponent<Image>();
            if (i == selectedIndex)
            {
                highlightImage.color = HighlightColor;
            }
            else
            {
                highlightImage.color = Color.white;
            }
        }
    }
}
