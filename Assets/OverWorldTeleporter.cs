using UnityEngine;
using UnityEngine.SceneManagement;

public class OverWorldTeleporter : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other) // This method is called when another collider enters the trigger collider attached to the GameObject this script is attached to.
    {
        if (other.CompareTag("Player")) // Check if the other collider has the tag "Player"
        {
            SceneManager.LoadScene("OverWorld"); // If the other collider is the player, load the scene named "platformerTestMap".
        }
    }
}
