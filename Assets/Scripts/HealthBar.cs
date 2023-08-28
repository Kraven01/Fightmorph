using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;

    public void Awake()
    {
        this.slider = this.GetComponent<Slider>();
    }

    public void SetMaxHealth(int health)
    {
        this.slider.maxValue = health;
        this.slider.value = health;
    }

    public void SetHealth(int health)
    {
        this.slider.value = health;
    }
}