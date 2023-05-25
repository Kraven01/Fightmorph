using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class UnshadowRoom : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private TilemapRenderer tileMapRenderer;

    [SerializeField]
    private GameObject slimePrefab;
    [SerializeField]
    private Transform spawnLocation;
    [SerializeField]
    private int numberOfEnemies;

    void Start() 
    { 

    }

    // Update is called once per frame
    void Update() { }

    void OnTriggerEnter2D(Collider2D other)
    {
        tileMapRenderer = GetComponent<TilemapRenderer>();
        
        Instantiate(slimePrefab, spawnLocation.position - new Vector3(3f,0f,0f), spawnLocation.rotation);
        for (int i = 0; i <numberOfEnemies; i++)
        {
            Instantiate(slimePrefab, spawnLocation.position - new Vector3(2f*i,0.5f*i,0f), spawnLocation.rotation);
        }
        if (tileMapRenderer == null)
        {
            tileMapRenderer = GetComponentInParent<TilemapRenderer>();
            tileMapRenderer.enabled = false;
            Destroy(transform.parent.gameObject);
        }
        else
        {
            tileMapRenderer.enabled = false;
            Destroy(gameObject);
        }
    }
}
