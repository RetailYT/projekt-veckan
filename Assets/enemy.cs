using UnityEngine;

public class enemy : MonoBehaviour
{
    public Transform target;
    public float speed = 2f;
    public float detectionRange = 5f;



    void Update()
    {
      transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }
}
