using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float speed = 5f;
    public float sprintMultiplier = 2f;
    public Transform cameraTransform;

    [Header("Sprint")]
    public float maxSprintTime = 5f;
    public float recoverySpeed = 1f;
    public float recoveryDelay = 5f;

    private float currentSprintTime;
    private float recoveryTimer;

    public bool isSprinting;

    [Header("References")]
    public AnimationController animationController;
    public GameManagerTwo gameManager;

    private AudioManager audioManager;

    private void Start()
    {
        currentSprintTime = maxSprintTime;
        audioManager = gameManager.audioManager.GetComponent<AudioManager>();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;

        forward.y = 0;
        right.y = 0;

        Vector3 move = forward * v + right * h;

        bool isMoving = move.magnitude > 0.1f;
        bool shiftPressed = Input.GetKey(KeyCode.LeftShift);

        // ===== SPRINT =====

        if (shiftPressed && currentSprintTime > 0f && isMoving)
        {
            isSprinting = true;

            currentSprintTime -= Time.deltaTime;
            recoveryTimer = 0f;

            if (currentSprintTime <= 0f)
            {
                currentSprintTime = 0f;
                isSprinting = false;
            }
        }
        else
        {
            isSprinting = false;

            recoveryTimer += Time.deltaTime;

            if (recoveryTimer >= recoveryDelay)
            {
                audioManager.StopBreatheSound();

                currentSprintTime += recoverySpeed * Time.deltaTime;
                currentSprintTime = Mathf.Clamp(
                    currentSprintTime,
                    0f,
                    maxSprintTime
                );
            }
            else
            {
                audioManager.PlayBreatheSound();
            }
        }

        // ===== MOVEMENT SOUND =====

        if (!isMoving)
        {
            audioManager.StopMovementSound();
        }
        else if (isSprinting)
        {
            audioManager.PlayRunSound();
        }
        else
        {
            audioManager.PlayWalkingSound();
        }

        // ===== MOVEMENT =====

        float currentSpeed =
            isSprinting
                ? speed * sprintMultiplier
                : speed;

        transform.position += move.normalized * currentSpeed * Time.deltaTime;

        if (isMoving)
        {
            transform.forward = move.normalized;
        }

        
    }

    public float GetSprintPercent()
    {
        return currentSprintTime / maxSprintTime;
    }
}