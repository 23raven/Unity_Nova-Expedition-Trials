using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class P5Manager : MonoBehaviour
{
    public TMP_Text dialogueText;
    public string[] phrases;
    public Button nextButton;
    public string nextSceneName;

    public AudioSource audioSource;
    public AudioClip[] audioPhrases;

    public Image characterImage;   // персонаж на сцене
    public Sprite[] poses;

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
        switch (currentPhrase)
        {
            case 0:
                characterImage.sprite = poses[0];
                break;
            case 1:
                characterImage.sprite = poses[1];
                break;
            case 2:
                characterImage.sprite = poses[2];
                break;
            case 3:
                characterImage.sprite = poses[3];
                break;
            default:
                characterImage.sprite = poses[0];
                break;
        }

    }
}