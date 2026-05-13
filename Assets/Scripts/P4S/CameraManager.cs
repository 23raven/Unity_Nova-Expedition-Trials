using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public Transform target;

    public float distance = 5f;
    public float height = 2f;

    public float mouseSensitivity = 3f;
    public float minY = -30f;
    public float maxY = 60f;

    private float yaw = 0f;
    private float pitch = 20f;


    void LateUpdate()
    {
        if (target == null) return;

        RotateCamera();
        FollowTarget();
    }

    void RotateCamera()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        yaw += mouseX;
        pitch -= mouseY;

        pitch = Mathf.Clamp(pitch, minY, maxY);

    }

    void FollowTarget()
    {
        Quaternion rotation = Quaternion.Euler(pitch, yaw, 0);
        Vector3 offset = rotation * new Vector3(0, height, -distance);

        Vector3 desiredPosition = target.position + offset;
        Vector3 lookTarget = target.position + Vector3.up * 1.5f;

        RaycastHit hit;

        if (Physics.Linecast(lookTarget, desiredPosition, out hit))
        {
            transform.position = hit.point + hit.normal * 0.5f;
        }
        else
        {
            transform.position = Vector3.Lerp(
                transform.position,
                desiredPosition,
                Time.deltaTime * 10f
            );
        }

        transform.LookAt(lookTarget);
    }
}