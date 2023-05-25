using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ImageSelection : MonoBehaviour
{
    [SerializeField]
    private GameObject[] images;
    private int selectedIndex = 0;

    public Color HighlightColor = Color.red;

    // Start is called before the first frame update
    void Start() { }

    // Update is called once per frame
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
        if (selectedIndex == 3) Application.Quit();
        else if (selectedIndex == 1)
        {
            Invoke("newGame", 0.25f);
        }
        images[selectedIndex].GetComponent<SpriteRenderer>().color = Color.white;
    }

    private void newGame(){
        SceneManager.LoadScene("IntroLevel");
    }


    public void HighlightSelectedImage()
    {
        for (int i = 0; i < images.Length; i++)
        {
            SpriteRenderer spriteRenderer = images[i].GetComponent<SpriteRenderer>();
            if (i == selectedIndex)
            {
                spriteRenderer.color = HighlightColor;
                spriteRenderer.size = new Vector2(
                    spriteRenderer.sprite.bounds.size.x + 0.2f,
                    spriteRenderer.sprite.bounds.size.y + 0.2f
                );
            }
            else
            {
                spriteRenderer.color = Color.white;
                spriteRenderer.size = spriteRenderer.sprite.bounds.size;
            }
        }
    }
}
