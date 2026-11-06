using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public int health = 100;
    public int damage = 10;

    public float damageCooldown = 1f;

    public TextMeshProUGUI healthText;

    private Vector3 spawnPosition;
    private float nextDamageTime = 0f;

    void Start()
    {
        spawnPosition = transform.position;
        UpdateHealthUI();
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            if (Time.time >= nextDamageTime)
            {
                health -= damage;

                nextDamageTime = Time.time + damageCooldown;

                if (health <= 0)
                {
                    transform.position = spawnPosition;
                    health = 100;
                }

                UpdateHealthUI();
            }
        }
    }

    void UpdateHealthUI()
    {
        if (healthText != null)
        {
            healthText.text = "HP: " + health;
        }
        else
        {
            Debug.LogWarning("Health Text is not assigned!");
        }
    }
}
