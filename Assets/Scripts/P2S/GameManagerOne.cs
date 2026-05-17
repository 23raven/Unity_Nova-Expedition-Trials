using UnityEngine;
using UnityEngine.UI;

public class GameManagerOne : MonoBehaviour
{
    public CameraController cameraController;

    // UI интерфейс
    public GameObject interfaceUI;

    // UI мини-игры
    public GameObject currentMiniGame;

    // объект планеты
    public PlanetManager currentPlanet;

    // счетчик завершенных игр
    public int miniGameCount = 0;

    // позиция камеры ДО приближения
    private Vector3 startCamPos;
    private Quaternion startCamRot;

    public Image[] planetIcons; // массив иконок планет для интерфейса 

    void Start()
    {
        startCamPos = cameraController.transform.position;
        startCamRot = cameraController.transform.rotation;
    }

    // вызывается при выборе планеты
    public void SelectPlanet()
    {
        interfaceUI.SetActive(false);
    }

    public void WinMiniGame(int miniGameNumber)
    {
        Debug.Log("MINIGAME COMPLETE");

        // вернуть интерфейс
        interfaceUI.SetActive(true);

        // вернуть камеру
        cameraController.ResetCamera();
        cameraController.transform.position = startCamPos;
        cameraController.transform.rotation = startCamRot;

        // выключить мини-игру
        Destroy(currentMiniGame);

        makeIconVisible(miniGameNumber);

        // отключить планету
        currentPlanet.enabled = false;
        currentPlanet.GetComponent<Collider>().enabled = false;

        // увеличить счетчик
        miniGameCount++;

        Debug.Log("MiniGames Completed: " + miniGameCount);
    }

    public void makeIconVisible(int mgn) { 
        if(mgn == 1) {
            planetIcons[0].color = Color.white;
        } else if(mgn == 2) {
            planetIcons[1].color = Color.white;
        } else if(mgn == 3) {
            planetIcons[2].color = Color.white;
        }
    }
}