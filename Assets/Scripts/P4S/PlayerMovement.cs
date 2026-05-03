using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public Transform cameraTransform;

    void Update()
    {
        float h = Input.GetAxis("Horizontal"); // A/D
        float v = Input.GetAxis("Vertical");   // W/S

        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;

        forward.y = 0;
        right.y = 0;

        Vector3 move = forward * v + right * h;

        transform.position += move * speed * Time.deltaTime;

        // поворот в сторону движения
        if (move != Vector3.zero)
        {
            transform.forward = move;
        }
    }
}