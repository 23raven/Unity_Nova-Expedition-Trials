using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MiniGameThree : MonoBehaviour
{
    public List<Dots> allDots;
    public RectTransform lineParent;
    public GameObject linePrefab; // UI Image (тонкая линия)

    private Dots firstDot;
    private int matchedPairs = 0;
    private int totalPairs = 3;

    public GameManagerOne gameManager;

    void Start()
    {
        foreach (var dot in allDots)
        {
            dot.Init(this);
        }
    }

    public void OnDotClicked(Dots dot)
    {
        if (firstDot == null)
        {
            firstDot = dot;
            return;
        }

        CheckMatch(firstDot, dot);
        firstDot = null;
    }

    void CheckMatch(Dots a, Dots b)
    {
        if (a == b) return;

        if (a.colorId == b.colorId)
        {
            Debug.Log("GOOD ✅");

            a.SetUsed();
            b.SetUsed();

            DrawLine(a.transform as RectTransform, b.transform as RectTransform, a.image.color);

            matchedPairs++;

            if (matchedPairs >= totalPairs)
            {
                Debug.Log("YOU WON 🎉");

                gameManager.WinMiniGame();
            }
        }
        else
        {
            Debug.Log("BAD ❌");
        }
    }

    void DrawLine(RectTransform a, RectTransform b, Color color)
    {
        GameObject line = Instantiate(linePrefab, lineParent);
        RectTransform rt = line.GetComponent<RectTransform>();
        Image img = line.GetComponent<Image>();

        img.color = color;

        Vector3 posA = a.position;
        Vector3 posB = b.position;

        Vector3 direction = posB - posA;
        float distance = direction.magnitude;

        rt.position = posA + direction / 2f;
        rt.sizeDelta = new Vector2(distance, 5f); // толщина 5px

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rt.rotation = Quaternion.Euler(0, 0, angle);
    }
}