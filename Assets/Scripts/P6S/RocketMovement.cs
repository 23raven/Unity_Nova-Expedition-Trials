using UnityEngine;

public class RocketMovement : MonoBehaviour
{
    [Tooltip("Speed in world units per second (for non-UI objects)")]
    public float speed = 10f;

    [Tooltip("Speed in pixels per second (for UI RectTransform). Increase for visible movement on Canvas.")]
    public float uiSpeed = 1000f;

    [Tooltip("Use raw input (no smoothing)")]
    public bool useRawInput = true;

    [Tooltip("Left boundary on X (pixels for UI, world units for non-UI)")]
    public float leftBoundary = -900f;

    [Tooltip("Right boundary on X (pixels for UI, world units for non-UI)")]
    public float rightBoundary = 900f;

    private RectTransform rectTransform;

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();

        // Гарантируем корректный порядок границ
        if (leftBoundary > rightBoundary)
        {
            float tmp = leftBoundary;
            leftBoundary = rightBoundary;
            rightBoundary = tmp;
        }
    }

    void Update()
    {
        float move = useRawInput ? Input.GetAxisRaw("Horizontal") : Input.GetAxis("Horizontal");
        if (Mathf.Approximately(move, 0f))
            return;

        float deltaTime = Time.deltaTime;

        if (rectTransform != null)
        {
            // Для UI: двигаем anchoredPosition в пикселях и клэмпим по границам
            Vector2 pos = rectTransform.anchoredPosition;
            float deltaX = move * uiSpeed * deltaTime;
            pos.x = Mathf.Clamp(pos.x + deltaX, leftBoundary, rightBoundary);
            rectTransform.anchoredPosition = pos;
        }
        else
        {
            // Для обычных объектов: двигаем в world/local единицах и клэмпим глобальную позицию
            Vector3 movement = new Vector3(move * speed * deltaTime, 0f, 0f);
            transform.Translate(movement, Space.Self);

            Vector3 worldPos = transform.position;
            worldPos.x = Mathf.Clamp(worldPos.x, leftBoundary, rightBoundary);
            transform.position = worldPos;
        }
    }
}