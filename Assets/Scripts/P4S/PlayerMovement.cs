using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float sprintMultiplier = 2f;

    public float maxSprintTime = 3f;     // максимум ускорения (сек)
    public float recoverySpeed = 1f;     // скорость восстановления

    public Transform cameraTransform;

    private float currentSprintTime;
    private bool isSprinting;

    void Start()
    {
        currentSprintTime = maxSprintTime;
    }

    void Update()
    {
        HandleSprint();

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;

        forward.y = 0;
        right.y = 0;

        Vector3 move = forward * v + right * h;

        float currentSpeed = speed;

        if (isSprinting)
        {
            currentSpeed *= sprintMultiplier;
        }

        transform.position += move * currentSpeed * Time.deltaTime;

        if (move != Vector3.zero)
        {
            transform.forward = move;
        }
    }

    void HandleSprint()
    {
        bool shift = Input.GetKey(KeyCode.LeftShift);

        if (shift && currentSprintTime > 0f)
        {
            isSprinting = true;
            currentSprintTime -= Time.deltaTime;
        }
        else
        {
            isSprinting = false;

            // восстановление
            if (currentSprintTime < maxSprintTime)
            {
                currentSprintTime += Time.deltaTime * recoverySpeed;
                currentSprintTime = Mathf.Clamp(currentSprintTime, 0f, maxSprintTime);
            }
        }
    }
}