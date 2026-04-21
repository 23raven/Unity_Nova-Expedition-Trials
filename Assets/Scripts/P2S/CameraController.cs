using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;

    private Vector3 localOffset;
    
    public float desiredDistance = 4f;

    public void SetTarget(Transform newTarget)
    {
        target = newTarget;

        // направление от планеты к камере
        Vector3 direction = (transform.position - target.position).normalized;

        // задаём НОВЫЙ offset с нужной дистанцией
        localOffset = direction * desiredDistance;
    }



    void LateUpdate()
    {
        if (target == null) return;

        // преобразуем обратно в мир
        Vector3 desiredPosition = target.TransformPoint(localOffset);

        transform.position = desiredPosition;
        transform.LookAt(target);
    }
}