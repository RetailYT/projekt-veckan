using UnityEngine;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public int health = 100;
    public int damage = 25;

    public TextMeshProUGUI healthText;

    void Start()
    {
        healthText.text = "HP: " + health;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Damage"))
        {
            health -= damage;

            if (health == 0)
            {
                Object.Destroy(gameObject);
            }

            healthText.text = "HP: " + health;
        }
    }
}
