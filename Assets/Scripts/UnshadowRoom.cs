using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class UnshadowRoom : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private TilemapRenderer tileMapRenderer;

    void Start() { }

    // Update is called once per frame
    void Update() { }

    void OnTriggerEnter2D(Collider2D other)
    {
        tileMapRenderer = GetComponent<TilemapRenderer>();
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
