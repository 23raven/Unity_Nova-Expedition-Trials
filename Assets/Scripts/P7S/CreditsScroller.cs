using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsScroller : MonoBehaviour
{
    [Header("References")]
    public RectTransform creditsContainer;
    public TMP_Text lastText;

    [Header("Settings")]
    public float scrollSpeed = 100f;
    public float finishY = 600f;

    private bool finished;

    private void Update()
    {
        if (finished)
            return;

        creditsContainer.anchoredPosition +=
            Vector2.up * scrollSpeed * Time.deltaTime;

        float lastTextBottom =
            lastText.rectTransform.position.y -
            (lastText.rectTransform.rect.height / 2f);

        if (lastTextBottom >= finishY)
        {
            finished = true;
            SceneManager.LoadScene("P0");

            Debug.Log("Credits finished");
        }
    }
}