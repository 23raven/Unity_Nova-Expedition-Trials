using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float zoomDistance = 3f;

    private Transform target;
    private bool isMoving = false;

    void Update()
    {
        if (isMoving && target != null)
        {
            MoveToTarget();
        }
    }

    public void FocusOnTarget(Transform newTarget)
    {
        target = newTarget;
        isMoving = true;
    }

    void MoveToTarget()
    {
        Vector3 direction = (transform.position - target.position).normalized;

        Vector3 desiredPosition = target.position + direction * zoomDistance;

        transform.position = Vector3.Lerp(
            transform.position,
            desiredPosition,
            Time.deltaTime * moveSpeed
        );

        transform.LookAt(target);

        // когда почти приехали — останавливаемся
        if (Vector3.Distance(transform.position, desiredPosition) < 0.05f)
        {
            isMoving = false;
        }
    }
}