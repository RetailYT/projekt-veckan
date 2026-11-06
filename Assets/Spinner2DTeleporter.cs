using UnityEngine;
using UnityEngine.SceneManagement;

public class levelTeleporter : MonoBehaviour
{
    public float rotationSpeed = 45f;

    private void Update()
    {
        // Snurrar antar jag
        transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SceneManager.LoadScene("level");
        }
    }
}
