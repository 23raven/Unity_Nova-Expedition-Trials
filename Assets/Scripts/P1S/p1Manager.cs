using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class p1Manager : MonoBehaviour
{
    public TMP_Text dialogueText;
    public string[] phrases;
    public Button nextButton;
    public string nextSceneName;

    public AudioSource audioSource;
    public AudioClip[] audioPhrases;

    public Image characterImage;   // персонаж на сцене
    public Sprite pose1;           // говорящая поза
    public Sprite pose2;           // другая поза

    private int currentPhrase = 0;

    void Start()
    {
        dialogueText.text = phrases[currentPhrase];
        nextButton.onClick.AddListener(NextPhrase);

        audioSource.clip = audioPhrases[currentPhrase];
        audioSource.Play();

        UpdateCharacterPose();
    }

    void NextPhrase()
    {
        currentPhrase++;

        if (currentPhrase >= phrases.Length)
        {
            SceneManager.LoadScene(nextSceneName);
            return;
        }

        dialogueText.text = phrases[currentPhrase];

        audioSource.Stop();
        audioSource.clip = audioPhrases[currentPhrase];
        audioSource.Play();

        UpdateCharacterPose();
    }

    void UpdateCharacterPose()
    {
        if (currentPhrase == 0 || currentPhrase == 3)
        {
            characterImage.sprite = pose1;
        }
        else if (currentPhrase == 1 || currentPhrase == 2)
        {
            characterImage.sprite = pose2;
        }
    }
}