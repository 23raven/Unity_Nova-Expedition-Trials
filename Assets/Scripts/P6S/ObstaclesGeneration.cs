using UnityEngine;

public class ObstaclesGeneration : MonoBehaviour
{
    [Header("Settings")]
    [Tooltip("Префаб препятствия")]
    public GameObject obstaclePrefab;

    [Tooltip("Точка старта (центр спавна)")]
    public Transform spawnPoint;

    [Header("Spawn Rules")]
    [Tooltip("Множитель размера (min, max)")]
    public Vector2 sizeMultiplierRange = new Vector2(0.8f, 1.4f);

    [Tooltip("Горизонтальный разброс")]
    public float horizontalSpread = 300f;

    [Tooltip("Интервал между появлением")]
    public float spawnInterval = 0.8f;

    [Header("Movement")]
    public float fallSpeed = 500f;
    public float bottomY = -1000f;

    [Tooltip("Автоматически определять, является ли объект UI")]
    public bool treatAsUI = true;

    [Header("Limits")]
    public int maxActive = 10;

    private float _timer;
    private int _activeCount;

    void Update()
    {
        if (obstaclePrefab == null || spawnPoint == null) return;
        if (maxActive > 0 && _activeCount >= maxActive) return;

        _timer += Time.deltaTime;
        if (_timer >= spawnInterval)
        {
            _timer = 0f;
            SpawnObstacle();
        }
    }

    private void SpawnObstacle()
    {
        // Спавним объект СРАЗУ как дочерний к spawnPoint
        GameObject go = Instantiate(obstaclePrefab, spawnPoint);

        // Рассчитываем случайное смещение по X
        float offsetX = Random.Range(-horizontalSpread, horizontalSpread);

        // Устанавливаем позицию относительно spawnPoint
        if (treatAsUI && go.GetComponent<RectTransform>() != null)
        {
            go.GetComponent<RectTransform>().anchoredPosition = new Vector2(offsetX, 0);
        }
        else
        {
            go.transform.localPosition = new Vector3(offsetX, 0, 0);
            // Если это не UI, отцепляем от родителя, чтобы он не двигался вместе с ним (по желанию)
            // go.transform.SetParent(null); 
        }

        // Масштабирование
        float mult = Random.Range(sizeMultiplierRange.x, sizeMultiplierRange.y);
        go.transform.localScale *= mult;

        // Настройка движения
        ObstacleMover mover = go.GetComponent<ObstacleMover>();
        if (mover == null) mover = go.AddComponent<ObstacleMover>();

        mover.Init(fallSpeed, bottomY, treatAsUI, () => {
            _activeCount = Mathf.Max(0, _activeCount - 1);
        });

        _activeCount++;
    }
}