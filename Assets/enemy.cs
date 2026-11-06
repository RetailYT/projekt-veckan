using UnityEngine;

public class enemy : MonoBehaviour
{
    public Transform target;
    public float speed = 2f;
    public float detectionRange = 50f;

    void Update()
    {
        float distance = Vector3.Distance(
            transform.position,
            target.position
        );

        if (distance <= detectionRange)
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                target.position,
                speed * Time.deltaTime
            );
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, detectionRange);
    }
}
