using UnityEngine;

public class RocketMovement : MonoBehaviour
{
    public float speed = 10f;
    public float leftBoundary = -8f;
    public float rightBoundary = 8f;
    public bool useRawInput = true;

    public GameManagerThree gameManager;

    private Rigidbody2D rb;
    private float move;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();

        if (leftBoundary > rightBoundary)
        {
            float tmp = leftBoundary;
            leftBoundary = rightBoundary;
            rightBoundary = tmp;
        }
    }

    void Update()
    {
        move = useRawInput
            ? Input.GetAxisRaw("Horizontal")
            : Input.GetAxis("Horizontal");
    }

    void FixedUpdate()
    {
        Vector2 newPos = rb.position + Vector2.right * move * speed * Time.fixedDeltaTime;

        newPos.x = Mathf.Clamp(newPos.x, leftBoundary, rightBoundary);

        rb.MovePosition(newPos);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Obstacle"))
        {
            gameManager.defeat();
        }
    }
}