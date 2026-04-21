using UnityEngine;

public class OrbitMovement : MonoBehaviour
{
    public Transform target;
    public float orbitSpeed = 20f;
    public Vector3 orbitAxis = Vector3.up;

    public float selfRotationSpeed = 50f; // вращение вокруг своей оси
    public Vector3 selfAxis = Vector3.up;

    void Update()
    {
        if (target != null)
        {
            // орбита вокруг target
            transform.RotateAround(target.position, orbitAxis, orbitSpeed * Time.deltaTime);
        }

        // вращение вокруг своей оси
        transform.Rotate(selfAxis, selfRotationSpeed * Time.deltaTime);
    }
}