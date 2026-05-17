using TMPro;
using UnityEngine;

public class dialogueManager : MonoBehaviour
{
    public TMP_Text dialogueText;
    public string[] phrases;

    public AudioSource audioSource;
    public AudioClip[] audioPhrases;

    public int delayTime = 1; // задержка в секундах

    private int currentPhraseIndex = 0;

    void OnEnable()
    {
        dialogueText.text = phrases[currentPhraseIndex];

        if (audioSource != null &&
            audioPhrases != null &&
            currentPhraseIndex < audioPhrases.Length)
        {
            audioSource.Stop();
            audioSource.clip = audioPhrases[currentPhraseIndex];
            audioSource.PlayDelayed(delayTime);
        }

        currentPhraseIndex++;
    }
}
