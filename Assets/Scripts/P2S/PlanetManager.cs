using Unity.VisualScripting;
using UnityEngine;

public class PlanetManager : MonoBehaviour
{
    public string planetName;
    public CameraController cameraController;
    public GameObject UICanvas;
    public GameObject MiniGame;
    public GameManagerOne gameManager;
    public bool requiresDialog;
    public GameObject dialogWindow;
    void OnMouseDown()
    {
        Debug.Log("You tapped on planet " + planetName);

        gameManager.currentMiniGame = MiniGame;
        gameManager.currentPlanet = this;
        gameManager.SelectPlanet();

        cameraController.SetTarget(transform);

        UICanvas.SetActive(true);
        MiniGame.SetActive(true);
    }
}