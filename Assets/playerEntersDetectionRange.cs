using System.Runtime.CompilerServices;
using UnityEngine;

public class playerEntersDetectionRange : MonoBehaviour
{
    [SerializeField]
    public bool playerInRange = false; // Flag to indicate if the player is in range

    public Transform player; // Reference to the player's transform

    private string playerTag = "Player"; // Tag to identify the player object


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(playerTag))
        {
            playerInRange = true; // Set the flag to true when the player enters the detection range
        }
    }
    
        
    private void OnTriggerExit2D(Collider2D other)
     { 
        if (other.CompareTag(playerTag))
        {
            playerInRange = false; // Set the flag to false when the player exits the detection range
            player = null; // Clear the reference to the player when they exit the detection range
        }
    }
}