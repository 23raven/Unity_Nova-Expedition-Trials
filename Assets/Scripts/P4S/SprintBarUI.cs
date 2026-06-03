using UnityEngine;
using UnityEngine.UI;

public class SprintBarUI : MonoBehaviour
{
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private Image fillImage;

    private void Update()
    {
        if (fillImage.fillAmount < 0.25f)
        {
            fillImage.color = Color.red;
        }
        else if (fillImage.fillAmount < 0.5f)
        {
            fillImage.color = Color.yellow;
        }
        else
        {
            fillImage.color = Color.green;
        }

        fillImage.fillAmount = playerMovement.GetSprintPercent();
    }

}