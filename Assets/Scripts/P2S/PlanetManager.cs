using Unity.VisualScripting;
using UnityEngine;

public class PlanetManager : MonoBehaviour
{
    public string planetName;
    public CameraController cameraController;
    public GameObject UICanvas;
    void OnMouseDown()
    {
        Debug.Log("You tapped on planet " + planetName);
        cameraController.SetTarget(transform);

        UICanvas.SetActive(true);
    }
}