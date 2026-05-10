using UnityEngine;

public class GameManagerOne : MonoBehaviour
{
    public CameraController cameraController;

    // UI мини-игры
    public GameObject currentMiniGame;

    // объект планеты
    public PlanetManager currentPlanet;

    // счетчик завершенных игр
    public int miniGameCount = 0;

    // позиция камеры ДО приближения
    private Vector3 startCamPos;
    private Quaternion startCamRot;



    void Start()
    {
        startCamPos = cameraController.transform.position;
        startCamRot = cameraController.transform.rotation;
    }

    public void WinMiniGame()
    {
        Debug.Log("MINIGAME COMPLETE");

        // 1. вернуть камеру
        cameraController.ResetCamera();

        cameraController.transform.position = startCamPos;
        cameraController.transform.rotation = startCamRot;

        // 2. выключить мини-игру
        Destroy(currentMiniGame);

        // 3. отключить PlanetManager
        currentPlanet.enabled = false;

        currentPlanet.GetComponent<Collider>().enabled = false;

        // 4. увеличить счетчик
        miniGameCount++;

        Debug.Log("MiniGames Completed: " + miniGameCount);
    }
}