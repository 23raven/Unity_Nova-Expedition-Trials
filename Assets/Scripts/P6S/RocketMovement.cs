using UnityEngine;

public class RocketMovement : MonoBehaviour
{
    [Tooltip("Speed in world units per second (for non-UI objects)")]
    public float speed = 10f;

    [Tooltip("Speed in pixels per second (for UI RectTransform). Increase for visible movement on Canvas.")]
    public float uiSpeed = 1000f;

    [Tooltip("Use raw input (no smoothing)")]
    public bool useRawInput = true;

    private RectTransform rectTransform;

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    void Update()
    {
        float move = useRawInput ? Input.GetAxisRaw("Horizontal") : Input.GetAxis("Horizontal");
        if (Mathf.Approximately(move, 0f))
            return;

        if (rectTransform != null)
        {
            // Для UI: двигаем anchoredPosition в пикселях
            Vector2 pos = rectTransform.anchoredPosition;
            pos.x += move * uiSpeed * Time.deltaTime;
            rectTransform.anchoredPosition = pos;
        }
        else
        {
            // Для обычных объектов: двигаем в world/local единицах
            Vector3 movement = new Vector3(move, 0f, 0f);
            transform.Translate(movement * speed * Time.deltaTime, Space.Self);
        }
    }
}