using UnityEngine;

public class pauseMenuButton : MonoBehaviour
{
    public GameObject pauseMenu;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            togglePauseMenu();
            Debug.Log(Time.timeScale);
        }
    }

    public void togglePauseMenu()
    {
        if (pauseMenu.activeSelf)
        {
            resumeGame();
        }
        else
        {
            Time.timeScale = 0f; // Pause the game
            pauseMenu.SetActive(true);
        }
    }

    public void resumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f; // Resume the game
    }
}
