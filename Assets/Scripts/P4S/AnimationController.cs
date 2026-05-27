using UnityEngine;

public class AnimationController : MonoBehaviour
{
    private Animator animator;
    private PlayerMovement playerMovement;

    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        playerMovement = GetComponent<PlayerMovement>();
    }

    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        float moveAmount = new Vector2(h, v).magnitude;

        float currentSpeed = 0f;

        if (moveAmount > 0.1f)
        {
            currentSpeed = playerMovement.isSprinting
                ? playerMovement.speed * playerMovement.sprintMultiplier
                : playerMovement.speed;
        }

        animator.SetFloat("speed", currentSpeed, 0.1f, Time.deltaTime);
    }

    public void PlayPickUp()
    {
        animator.SetTrigger("pickUp");
    }
}