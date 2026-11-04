using UnityEngine;

public class turnOffEnemy : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other) // This method is called when another collider enters the trigger collider attached to the GameObject this script is attached to.
    {
        if (other.CompareTag("Enemy")) // Check if the other collider has the tag "Enemy"
        {
            other.gameObject.SetActive(false); //Turns off the enemy GameObject
        }
    }
}
