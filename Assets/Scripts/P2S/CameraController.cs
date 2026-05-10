using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public float followSpeed = 5f;

    private Vector3 localOffset;
    private Camera cam;

    private Rect targetRect;
    private bool isResizing = false;

    private Rect defaultRect;

    void Awake()
    {
        cam = GetComponent<Camera>();
        defaultRect = cam.rect;
    }

    public void SetTarget(Transform newTarget, float distance = 4f)
    {
        target = newTarget;

        Vector3 direction = (transform.position - target.position).normalized;
        localOffset = direction * distance;

        // 🎯 задаём целевой viewport (центр экрана)
        targetRect = new Rect(0.2f, 0.4f, 0.6f, 0.4f);
        isResizing = true;
    }

    void LateUpdate()
    {
        if (target != null)
        {
            Vector3 desiredPosition = target.TransformPoint(localOffset);

            transform.position = Vector3.Lerp(
                transform.position,
                desiredPosition,
                Time.deltaTime * followSpeed
            );

            transform.LookAt(target);
        }

        if (isResizing)
        {
            cam.rect = LerpRect(cam.rect, targetRect, Time.deltaTime * 3f);

            if (Mathf.Abs(cam.rect.width - targetRect.width) < 0.01f)
            {
                isResizing = false;
            }
        }
    }

    Rect LerpRect(Rect a, Rect b, float t)
    {
        return new Rect(
            Mathf.Lerp(a.x, b.x, t),
            Mathf.Lerp(a.y, b.y, t),
            Mathf.Lerp(a.width, b.width, t),
            Mathf.Lerp(a.height, b.height, t)
        );
    }

    public void ResetCamera()
    {
        target = null;

        targetRect = defaultRect;
        isResizing = true;
    }
}