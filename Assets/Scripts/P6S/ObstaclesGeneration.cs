using UnityEngine;

public class ObstaclesGeneration : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public Transform spawnPoint;

    public Vector2 sizeMultiplierRange = new Vector2(0.8f, 1.4f);
    public float horizontalSpread = 5f;
    public float spawnInterval = 0.8f;

    public float fallSpeed = 5f;
    public float bottomY = -6f;

    public int maxActive = 10;

    private float timer;
    private int activeCount;

    void Update()
    {
        if (obstaclePrefab == null || spawnPoint == null) return;
        if (activeCount >= maxActive) return;

        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            timer = 0f;
            SpawnObstacle();
        }
    }

    void SpawnObstacle()
    {
        float offsetX = Random.Range(-horizontalSpread, horizontalSpread);

        Vector3 spawnPos = spawnPoint.position + new Vector3(offsetX, 0f, 0f);

        GameObject go = Instantiate(obstaclePrefab, spawnPos, Quaternion.identity);

        float mult = Random.Range(sizeMultiplierRange.x, sizeMultiplierRange.y);
        go.transform.localScale *= mult;

        ObstacleMover mover = go.GetComponent<ObstacleMover>();

        if (mover == null)
            mover = go.AddComponent<ObstacleMover>();

        mover.Init(fallSpeed, bottomY, false, () =>
        {
            activeCount--;
        });

        activeCount++;
    }
}