using UnityEngine;

public class DamageNumber : MonoBehaviour
{
    public float destroyDelay = 1f; // Delay after which the damage number is destroyed
    private float destroyTime;
    public float moveSpeed = 2f; // Speed at which the damage number moves up
    private Color textColor;

    private TextMesh textMesh;

    private void Awake()
    {
        this.textMesh = this.GetComponent<TextMesh>();
    }

    private void Start()
    {
        this.destroyTime = Time.time + this.destroyDelay;
    }

    private void Update()
    {
        // Move the damage number upwards
        this.transform.position += Vector3.up * this.moveSpeed * Time.deltaTime;

        // Fade out the damage number over time
        float alpha = Mathf.Lerp(1f, 0f, (Time.time - this.destroyTime) / this.destroyDelay);
        this.textColor = new Color(this.textColor.r, this.textColor.g, this.textColor.b, alpha);
        this.textMesh.color = this.textColor;

        // Destroy the damage number after the destroy delay
        if (Time.time >= this.destroyTime)
        {
            Destroy(this.gameObject);
        }
    }

    public void SetDamageNumber(int damage)
    {
        this.textMesh.text = damage.ToString();
    }

    public void SetColor(Color color)
    {
        this.textColor = color;
        this.textMesh.color = this.textColor;
    }
}