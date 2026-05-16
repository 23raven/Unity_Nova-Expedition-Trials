using UnityEngine;
using UnityEngine.SceneManagement;

public class restartButtonP6S : MonoBehaviour
{
    public void RestartScene()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}