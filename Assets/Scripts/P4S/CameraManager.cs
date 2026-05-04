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

     
        transform.position = Vector3.Lerp(
        transform.position,
        target.position + offset,
        Time.deltaTime * 10f
);
        transform.LookAt(target.position + Vector3.up * 1.5f);
    }
}