using UnityEngine;
using UnityEngine.Tilemaps;

public class UnshadowRoom : MonoBehaviour
{
    [SerializeField] private int numberOfEnemies;

    [SerializeField] private GameObject slimePrefab;

    [SerializeField] private Transform spawnLocation;

    // Start is called before the first frame update
    [SerializeField] private TilemapRenderer tileMapRenderer;

    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        this.tileMapRenderer = this.GetComponent<TilemapRenderer>();

        Instantiate(this.slimePrefab, this.spawnLocation.position - new Vector3(3f, 0f, 0f),
            this.spawnLocation.rotation);
        for (int i = 0; i < this.numberOfEnemies; i++)
        {
            Instantiate(this.slimePrefab, this.spawnLocation.position - new Vector3(2f * i, 0.5f * i, 0f),
                this.spawnLocation.rotation);
        }

        if (this.tileMapRenderer == null)
        {
            this.tileMapRenderer = this.GetComponentInParent<TilemapRenderer>();
            this.tileMapRenderer.enabled = false;
            Destroy(this.transform.parent.gameObject);
        }
        else
        {
            this.tileMapRenderer.enabled = false;
            Destroy(this.gameObject);
        }
    }
}