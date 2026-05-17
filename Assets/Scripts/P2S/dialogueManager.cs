using TMPro;
using UnityEngine;

public class dialogueManager : MonoBehaviour
{
    public TMP_Text dialogueText;
    [TextArea] public string startPhrase;

    public AudioSource audioSource;
    public AudioClip startAudio;

    void Start()
    {
        dialogueText.text = startPhrase;

        if (startAudio != null && audioSource != null)
        {
            audioSource.clip = startAudio;
            audioSource.Play();
        }
    }
}