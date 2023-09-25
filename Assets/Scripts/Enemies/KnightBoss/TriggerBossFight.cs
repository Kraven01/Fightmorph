using UnityEngine;

public class TriggerBossFight : MonoBehaviour
{
    public GameObject BossHealthbar;

    private void OnTriggerEnter2D(Collider2D others)
    {
        this.BossHealthbar.SetActive(true);
    }
}