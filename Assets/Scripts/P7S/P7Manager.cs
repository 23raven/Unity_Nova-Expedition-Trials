using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class P7Manager : MonoBehaviour
{
    [Header("Dialogue")]
    public TMP_Text dialogueText;
    public string[] phrases;
    public Button nextButton;

    [Header("Voice")]
    public AudioSource audioSource;
    public AudioClip[] audioPhrases;

    [Header("Character")]
    public Image characterImage;
    public Sprite[] poses;

    [Header("UI")]
    public GameObject visualNovel;
    public GameObject titles;

    private int currentPhrase = 0;

    private void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        titles.SetActive(false);

        dialogueText.text = phrases[currentPhrase];

        nextButton.onClick.AddListener(NextPhrase);

        if (audioPhrases.Length > 0)
        {
            audioSource.clip = audioPhrases[currentPhrase];
            audioSource.Play();
        }

        UpdateCharacterPose();
    }

    private void NextPhrase()
    {
        currentPhrase++;

        if (currentPhrase >= phrases.Length)
        {
            DisableAllAudio();

            visualNovel.SetActive(false);
            titles.SetActive(true);

            return;
        }

        dialogueText.text = phrases[currentPhrase];

        audioSource.Stop();

        if (currentPhrase < audioPhrases.Length)
        {
            audioSource.clip = audioPhrases[currentPhrase];
            audioSource.Play();
        }

        UpdateCharacterPose();
    }

    private void DisableAllAudio()
    {
        AudioSource[] allAudioSources = FindObjectsByType<AudioSource>(
            FindObjectsSortMode.None
        );

        foreach (AudioSource source in allAudioSources)
        {
            source.Stop();
            source.enabled = false;
        }
    }

    private void UpdateCharacterPose()
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

            case 4:
                characterImage.sprite = poses[4];
                break;

            case 5:
                characterImage.sprite = poses[5];
                break;

            case 6:
                characterImage.sprite = poses[6];
                break;

            default:
                characterImage.sprite = poses[0];
                break;
        }
    }
}