using UnityEngine;
using UnityEngine.Tilemaps;

public class UnshadowRoom : MonoBehaviour
{
    private BoxCollider2D boxCollider2D;
    [SerializeField] private GameObject laserEnemyPrefab;
    [SerializeField] private int numberOfEnemies;

    [SerializeField] private GameObject slimePrefab;

    [SerializeField] private Transform spawnLocation;

    // Start is called before the first frame update
    [SerializeField] private TilemapRenderer tileMapRenderer;

    private void Start()
    {
        this.spawnLocation = this.transform.Find("spawnLocation")?.transform;
        this.boxCollider2D = this.GetComponent<BoxCollider2D>();
        this.tileMapRenderer = this.GetComponent<TilemapRenderer>();
        if (this.tileMapRenderer != null)
        {
            this.tileMapRenderer.enabled = false;
        }

        if (this.spawnLocation == null)
        {
            this.spawnLocation = this.transform.Find("SecondEntrance").transform.Find("spawnLocation").transform;
        }
    }

    // Update is called once per frame
    private void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        for (int i = 0; i < this.numberOfEnemies; i++)
        {
            float spawnDecider = Random.value;
            if (spawnDecider < 0.5)
            {
                Instantiate(this.slimePrefab, this.spawnLocation.position - new Vector3(2f * i, 0.5f * i, 0f),
                    this.spawnLocation.rotation);
            }
            else
            {
                Instantiate(this.laserEnemyPrefab, this.spawnLocation.position - new Vector3(2f * i, 0.5f * i, 0f),
                    this.spawnLocation.rotation);
            }
        }

        // this.tileMapRenderer.enabled = false;

        Destroy(this.gameObject);
    }
}