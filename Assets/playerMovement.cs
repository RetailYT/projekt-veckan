using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float moveSpeed = 5f;
    public float stamina = 100f;
    public float sprintSpeed = 8f;

    private float x;
    private float y;
    private float regenTimer = 0f;

    void Start()
    {

    }

    void Update()
    {
        x = Input.GetAxisRaw("Horizontal");
        y = Input.GetAxisRaw("Vertical");

        if (Input.GetKey(KeyCode.X) && stamina > 0)
        {
            stamina -= 40f * Time.deltaTime;
            regenTimer = 3f;
        }
        else if (regenTimer > 0)
        {
            regenTimer -= Time.deltaTime;
        }
        else
        {
            stamina += 30f * Time.deltaTime;
        }

        stamina = Mathf.Clamp(stamina, 0, 100);
    }

    void FixedUpdate()
    {
        float speed = moveSpeed;

        if (Input.GetKey(KeyCode.X) && stamina > 0)
        {
            speed = sprintSpeed;
        }

        rb.linearVelocity = new Vector2(x, y) * speed;
    }
}
