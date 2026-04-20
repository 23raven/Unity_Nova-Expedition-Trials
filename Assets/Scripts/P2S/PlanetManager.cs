using UnityEngine;

public class PlanetManager : MonoBehaviour
{
    public string planetName;

    void OnMouseDown()
    {
        Debug.Log("You tapped on planet " + planetName);
    }
}