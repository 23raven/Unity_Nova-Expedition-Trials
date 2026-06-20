using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditsScroller : MonoBehaviour
{
    [Header("References")]
    public RectTransform creditsContainer;
    public TMP_Text lastText;
    public float maxVolume = 0.5f;

    [Header("Settings")]
    public float scrollSpeed = 100f;
    public float finishY = 600f;

    [Header("Music")]
    public AudioSource musicSource;
    public float fadeInDuration = 3f;
    public float fadeOutDuration = 5f;

    private bool finished;

    private void Start()
    {
        Time.timeScale = 1f;
        if (musicSource != null)
        {
            musicSource.volume = 0f;
            musicSource.Play();

            StartCoroutine(FadeInMusic());
        }
    }

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

            StartCoroutine(EndCredits());
        }
    }

    private IEnumerator FadeInMusic()
    {
        float timer = 0f;

        while (timer < fadeInDuration)
        {
            timer += Time.deltaTime;

            musicSource.volume =
                Mathf.Lerp(0f, maxVolume, timer / fadeInDuration);

            yield return null;
        }

        musicSource.volume = maxVolume;
    }

    private IEnumerator EndCredits()
    {
        float startVolume = musicSource.volume;
        float timer = 0f;

        while (timer < fadeOutDuration)
        {
            timer += Time.deltaTime;

            musicSource.volume =
                Mathf.Lerp(
                    startVolume,
                    0f,
                    timer / fadeOutDuration
                );

            yield return null;
        }

        musicSource.Stop();

        SceneManager.LoadScene("P0");
    }
}