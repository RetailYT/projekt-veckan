using UnityEditor;
using UnityEngine;

public class killPlayer : MonoBehaviour
{
    public GameObject player; // Reference to the player GameObject that will be destroyed when the player collides with the spike.

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Spike"))
        {
            player.SetActive(false); // Deactivate the player GameObject when it collides with the spike.
        }
    }
}
