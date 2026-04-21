using UnityEngine;

public class PlanetManager : MonoBehaviour
{
    public string planetName;
    public CameraController cameraController;

    void OnMouseDown()
    {
        Debug.Log("You tapped on planet " + planetName);
        cameraController.SetTarget(transform);
    }
}