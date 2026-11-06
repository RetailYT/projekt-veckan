using UnityEngine;

public class killPlayer : MonoBehaviour
{
    public GameObject player;

    private Vector3 spawnPosition;

    void Start()
    {
        spawnPosition = player.transform.position;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Spike"))
        {
            player.transform.position = spawnPosition;
        }
    }
}
