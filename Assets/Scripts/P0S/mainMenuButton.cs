using UnityEngine;

public class mainMenuButton : MonoBehaviour
{
    public void backToMainMenu()
    {
        Time.timeScale = 1f; // Ensure the game is not paused
        UnityEngine.SceneManagement.SceneManager.LoadScene("P0");
    }
}
