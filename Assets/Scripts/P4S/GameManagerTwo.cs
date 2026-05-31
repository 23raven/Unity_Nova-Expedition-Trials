using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerTwo : MonoBehaviour
{
    public GameObject startMenu;
    public Button startButton;
    public GameObject defeatMenu;
    public GameObject backText;
    public GameObject inGameUI;
    public TMP_Text coinsText;
    public GameObject victoryMenu;

    void Start()
    {
        Time.timeScale = 0f;

        startButton.onClick.AddListener(StartGame);

        Debug.Log("START: " + Time.timeScale);
    }

    void Update()
    {
        coinsText.text = "Solar Pearls: " + FindObjectOfType<PlayerManager>().coins;
    }

    public void StartGame()
    {
        Time.timeScale = 1f;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        startMenu.SetActive(false);
        inGameUI.SetActive(true);

    }

    public void Defeat()
    {
        Time.timeScale = 0f;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        defeatMenu.SetActive(true);
    }

    public void showBackText()
    {
         backText.SetActive(true);
    }

    public void Victory()
    {
        Time.timeScale = 0f;
        inGameUI.SetActive(false);
        victoryMenu.SetActive(true);
    }

}