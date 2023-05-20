using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageNumber : MonoBehaviour
{
    public float moveSpeed = 2f;     // Speed at which the damage number moves up
    public float destroyDelay = 1f;  // Delay after which the damage number is destroyed

    private TextMesh textMesh;
    private Color textColor;
    private float destroyTime;

    private void Awake()
    {
        textMesh = GetComponent<TextMesh>();
    }

    private void Start()
    {
        destroyTime = Time.time + destroyDelay;
    }

    private void Update()
    {
        // Move the damage number upwards
        transform.position += Vector3.up * moveSpeed * Time.deltaTime;

        // Fade out the damage number over time
        float alpha = Mathf.Lerp(1f, 0f, (Time.time - destroyTime) / destroyDelay);
        textColor = new Color(textColor.r, textColor.g, textColor.b, alpha);
        textMesh.color = textColor;

        // Destroy the damage number after the destroy delay
        if (Time.time >= destroyTime)
        {
            Destroy(gameObject);
        }
    }

    public void SetDamageNumber(int damage)
    {
        textMesh.text = damage.ToString();
    }

    public void SetColor(Color color)
    {
        textColor = color;
        textMesh.color = textColor;
    }
}
