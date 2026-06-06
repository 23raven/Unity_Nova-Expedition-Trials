using TMPro;
using UnityEngine;

public class GameManagerThree : MonoBehaviour
{
    public GameObject startUI;
    public GameObject defeatUI;
    public GameObject victoryUI;
    public TMP_Text timeText;

    private float timeLeft = 30f;
    private bool gameEnded = false;

        void Start()
        {
            Time.timeScale = 0f;
            startUI.SetActive(true);
            defeatUI.SetActive(false);
            victoryUI.SetActive(false);
        }
    
        public void StartGame()
        {
            Time.timeScale = 1f;
            startUI.SetActive(false);
        
    }

    void Update()
    {
        if (gameEnded) return;

        timeLeft -= Time.deltaTime;

        timeText.text = Mathf.Ceil(timeLeft).ToString();

        if (timeLeft <= 0f)
        {
            gameEnded = true;
            victoryUI.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void defeat()
    {
        if (gameEnded) return;

        gameEnded = true;
        defeatUI.SetActive(true);
        Time.timeScale = 0f;
    }
}