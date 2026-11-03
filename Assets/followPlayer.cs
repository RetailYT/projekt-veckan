using UnityEngine;
public class followPlayer : MonoBehaviour
{
    public Transform player; // Reference to the player's transform
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.position + new Vector3(0, 0, -10); // Keep the camera at a fixed distance behind the player
    }
}
