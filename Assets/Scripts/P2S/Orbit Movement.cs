using UnityEngine;

public class OrbitMovement : MonoBehaviour
{
    public Transform target;   // объект, вокруг которого крутимся
    public float speed = 20f;  // скорость вращения
    public Vector3 axis = Vector3.up; // ось вращения (обычно вверх)

    void Update()
    {
        if (target != null)
        {
            transform.RotateAround(target.position, axis, speed * Time.deltaTime);
        }
    }
}