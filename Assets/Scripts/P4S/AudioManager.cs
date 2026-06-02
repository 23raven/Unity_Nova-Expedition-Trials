using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("Audio Sources")]
    [SerializeField] private AudioSource gameAudioSource;
    [SerializeField] private AudioSource playerAudioSource;

    [Header("GAME")]
    [SerializeField] private AudioClip backgroundNoise;
    [SerializeField] private AudioClip backgroundMusic;
    [SerializeField] private AudioClip deathSound;

    [Header("PLAYER")]
    [SerializeField] private AudioClip pickUpSound;
    [SerializeField] private AudioClip walkingSound;
    [SerializeField] private AudioClip runSound;
    [SerializeField] private AudioClip breatheSound;

    #region GAME

    public void PlayBackgroundNoise()
    {
        gameAudioSource.PlayOneShot(backgroundNoise);
    }

    public void PlayBackgroundMusic()
    {
        gameAudioSource.PlayOneShot(backgroundMusic);
    }

    public void PlayDeathSound()
    {
        gameAudioSource.PlayOneShot(deathSound);
    }

    #endregion

    #region PLAYER

    public void PlayPickUpSound()
    {
        playerAudioSource.PlayOneShot(pickUpSound);
    }

    public void PlayWalkingSound()
    {
        playerAudioSource.PlayOneShot(walkingSound);
    }

    public void PlayRunSound()
    {
        playerAudioSource.PlayOneShot(runSound);
    }

    public void PlayBreatheSound()
    {
        playerAudioSource.PlayOneShot(breatheSound);
    }

    #endregion
}