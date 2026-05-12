using UnityEngine;
using UnityEngine.UI;

public class GameManagerTwo : MonoBehaviour
{
    public GameObject startMenu;
    public Button startButton;
    public GameObject defeatMenu;

    void Start()
    {
        Time.timeScale = 0f;

        startButton.onClick.AddListener(StartGame);

        Debug.Log("START: " + Time.timeScale);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Debug.Log("Mouse Click");
        }
    }

    public void StartGame()
    {
        Time.timeScale = 1f;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        startMenu.SetActive(false);
    }

    public void Defeat()
    {
        Time.timeScale = 0f;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        defeatMenu.SetActive(true);
    }

}