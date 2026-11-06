using UnityEngine;

public class MaceFollow : MonoBehaviour
{
    public Transform player;

    public float cameraDistance = 5f;

    void Update()
    {
        transform.position = player.position + new Vector3(0, 0, -cameraDistance);
    }
}
