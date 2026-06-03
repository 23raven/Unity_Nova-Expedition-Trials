using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [Header("GAME SOURCES")]
    [SerializeField] private AudioSource backgroundMusicSource;
    [SerializeField] private AudioSource backgroundNoiseSource;
    [SerializeField] private AudioSource gameSfxSource;

    [Header("PLAYER SOURCES")]
    [SerializeField] private AudioSource movementSource;
    [SerializeField] private AudioSource breatheSource;

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

    public void PlayBackgroundMusic()
    {
        if (backgroundMusicSource.isPlaying)
            return;

        backgroundMusicSource.clip = backgroundMusic;
        backgroundMusicSource.loop = true;
        backgroundMusicSource.Play();
    }

    public void PlayBackgroundNoise()
    {
        if (backgroundNoiseSource.isPlaying)
            return;

        backgroundNoiseSource.clip = backgroundNoise;
        backgroundNoiseSource.loop = true;
        backgroundNoiseSource.Play();
    }

    public void PlayDeathSound()
    {
        gameSfxSource.PlayOneShot(deathSound);
    }

    #endregion

    #region PLAYER

    public void PlayPickUpSound()
    {
        gameSfxSource.PlayOneShot(pickUpSound);
    }

    public void PlayWalkingSound()
    {
        if (movementSource.clip == walkingSound && movementSource.isPlaying)
            return;

        movementSource.clip = walkingSound;
        movementSource.loop = true;
        movementSource.Play();
    }

    public void PlayRunSound()
    {
        if (movementSource.clip == runSound && movementSource.isPlaying)
            return;

        movementSource.clip = runSound;
        movementSource.loop = true;
        movementSource.Play();
    }

    public void StopMovementSound()
    {
        movementSource.Stop();
    }

    public void PlayBreatheSound()
    {
        if (breatheSource.isPlaying)
            return;

        breatheSource.clip = breatheSound;
        breatheSource.loop = true;
        breatheSource.Play();
    }

    public void StopBreatheSound()
    {
        breatheSource.Stop();
    }

    #endregion
}