using TMPro;
using UnityEngine;

public class TextPulse : MonoBehaviour
{
    public TMP_Text targetText;

    public float pulseSpeed = 2f;      // скорость пульсации
    public float pulseAmount = 0.1f;   // насколько увеличивать (10%)

    private Vector3 originalScale;

    void Start()
    {
        originalScale = targetText.transform.localScale;
    }

    void Update()
    {
        float scale = 1f + Mathf.Sin(Time.time * pulseSpeed) * pulseAmount;
        targetText.transform.localScale = originalScale * scale;
    }
}