using UnityEngine;
using UnityEngine.SceneManagement;

public class ImageSelection : MonoBehaviour
{
    public Color HighlightColor = Color.red;

    [SerializeField] private GameObject[] images;

    private int selectedIndex;

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
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

        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.DownArrow))
        {
            this.selectedIndex += Input.GetKeyDown(KeyCode.UpArrow) ? -1 : 1;

            if (this.selectedIndex < 0)
            {
                this.selectedIndex = this.images.Length - 1;
            }
            else if (this.selectedIndex >= this.images.Length)
            {
                this.selectedIndex = 0;
            }

            this.HighlightSelectedImage();
        }

        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S))
        {
            this.selectedIndex += Input.GetKeyDown(KeyCode.W) ? -1 : 1;

            if (this.selectedIndex < 0)
            {
                this.selectedIndex = this.images.Length - 1;
            }
            else if (this.selectedIndex >= this.images.Length)
            {
                this.selectedIndex = 0;
            }

            this.HighlightSelectedImage();
        }

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Return))
        {
            this.HandleConfirmationEvent();
        }
    }


    private void HandleConfirmationEvent()
    {
        if (this.selectedIndex == 3)
        {
            Application.Quit();
        }
        else if (this.selectedIndex == 1)
        {
            this.Invoke("newGame", 0.25f);
        }

        this.images[this.selectedIndex].GetComponent<SpriteRenderer>().color = Color.white;
    }

    private void newGame()
    {
        SceneManager.LoadScene("IntroLevel");
    }


    public void HighlightSelectedImage()
    {
        for (int i = 0; i < this.images.Length; i++)
        {
            SpriteRenderer spriteRenderer = this.images[i].GetComponent<SpriteRenderer>();
            if (i == this.selectedIndex)
            {
                spriteRenderer.color = this.HighlightColor;
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