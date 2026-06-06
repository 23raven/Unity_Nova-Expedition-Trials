using TMPro;
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManagerThree : MonoBehaviour
{
    public GameObject startUI;
    public GameObject defeatUI;
    public GameObject victoryUI;
    public TMP_Text timeText;

    private float timeLeft = 30f;
    private bool gameEnded = false;

    public AudioSource musicSource;

    void Start()
        {
            Time.timeScale = 0f;
            startUI.SetActive(true);
            defeatUI.SetActive(false);
            victoryUI.SetActive(false);
            
    }
    
        public void StartGame()
        {
            Time.timeScale = 1f;
            startUI.SetActive(false);
            musicSource.Play();
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.None;
    }

    void Update()
    {
        if (gameEnded) return;

        timeLeft -= Time.deltaTime;

        timeText.text = Mathf.Ceil(timeLeft).ToString();

        if (timeLeft <= 0f)
        {
            gameEnded = true;
            victoryUI.SetActive(true);
            Time.timeScale = 0f;

            StartCoroutine(VictorySequence());
        }
    }

    public void defeat()
    {
        if (gameEnded) return;

        gameEnded = true;
        defeatUI.SetActive(true);
        Time.timeScale = 0f;
    }

    private IEnumerator VictorySequence()
    {
        float startVolume = musicSource.volume;

        float timer = 0f;
        float fadeDuration = 5f;

        while (timer < fadeDuration)
        {
            timer += Time.unscaledDeltaTime;

            musicSource.volume = Mathf.Lerp(
                startVolume,
                0f,
                timer / fadeDuration
            );

            yield return null;
        }

        SceneManager.LoadScene("P7");
    }
}