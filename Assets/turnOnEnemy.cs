using UnityEngine;

public class turnOnEnemy : MonoBehaviour
{

    public GameObject enemy; // Reference to the enemy GameObject that will be turned off when the player enters the trigger.

    private void OnTriggerEnter2D(Collider2D other) // This method is called when another collider enters the trigger collider attached to the GameObject this script is attached to.
    {
        if (other.CompareTag("Player")) // Check if the other collider has the tag "Player"
        {
            enemy.gameObject.SetActive(true);  // If the other collider is the player, deactivate the enemy GameObject.
        }
    }
}
