using Unity.VisualScripting;
using UnityEngine;

public class PlanetManager : MonoBehaviour
{
    public string planetName;
    public CameraController cameraController;
    public GameObject UICanvas;
    public GameObject MiniGame;
    void OnMouseDown()
    {
        Debug.Log("You tapped on planet " + planetName);
        cameraController.SetTarget(transform);

        UICanvas.SetActive(true);
        MiniGame.SetActive(true);
    }
}