using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float speed = 5f;
    public float sprintMultiplier = 2f;
    public Transform cameraTransform;

    [Header("Sprint")]
    public float maxSprintTime = 3f;
    public float recoverySpeed = 1f;
    public float recoveryDelay = 1f; // задержка перед восстановлением

    private float currentSprintTime;
    private float recoveryTimer;
    private bool isSprinting;

    void Start()
    {
        currentSprintTime = maxSprintTime;
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;

        forward.y = 0;
        right.y = 0;

        Vector3 move = forward * v + right * h;

        bool shift = Input.GetKey(KeyCode.LeftShift);

        // 💥 СПРИНТ ВКЛЮЧАЕТСЯ ТОЛЬКО ЕСЛИ ЕСТЬ ЭНЕРГИЯ
        if (shift && currentSprintTime > 0f && move.magnitude > 0.1f)
        {
            isSprinting = true;

            currentSprintTime -= Time.deltaTime;
            recoveryTimer = 0f; // сбрасываем таймер восстановления

            if (currentSprintTime <= 0f)
            {
                currentSprintTime = 0f;
                isSprinting = false;
            }
        }
        else
        {
            isSprinting = false;

            // ⏳ задержка перед восстановлением
            recoveryTimer += Time.deltaTime;

            if (recoveryTimer >= recoveryDelay)
            {
                currentSprintTime += Time.deltaTime * recoverySpeed;
                currentSprintTime = Mathf.Clamp(currentSprintTime, 0f, maxSprintTime);
            }
        }

        float currentSpeed = isSprinting ? speed * sprintMultiplier : speed;

        transform.position += move * currentSpeed * Time.deltaTime;

        if (move != Vector3.zero)
        {
            transform.forward = move;
        }
    }
}