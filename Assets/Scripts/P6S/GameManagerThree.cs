using TMPro;
using UnityEngine;

public class GameManagerThree : MonoBehaviour
{
    public GameObject startUI;
    public GameObject defeatUI;
    public GameObject victoryUI;
    public TMP_Text timeText;

    public void defeat() { 
        defeatUI.SetActive(true);   
        Time.timeScale = 0f;    
    }

}
