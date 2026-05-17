using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class MiniGameOne : MonoBehaviour
{
    public RectTransform horizontalBlack;
    public RectTransform horizontalGreen;
    public RectTransform verticalGreen;

    public GameManagerOne gameManager;
    private bool isCompleted = false;

    public float speed = 2f;

    private float t;

    void Update()
    {
        MoveIndicator();
        CheckInput();
    }

    void MoveIndicator()
    {
        t += Time.deltaTime * speed;

        float pingPong = Mathf.PingPong(t, 1f);

        // границы движения (по X)
        float minX = horizontalBlack.position.x - horizontalBlack.rect.width / 2;
        float maxX = horizontalBlack.position.x + horizontalBlack.rect.width / 2;

        float x = Mathf.Lerp(minX, maxX, pingPong);

        verticalGreen.position = new Vector3(
            x,
            verticalGreen.position.y,
            verticalGreen.position.z
        );
    }

    void CheckInput()
    {
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            CheckHit();
        }
    }

    void CheckHit()
    {
        float indicatorX = verticalGreen.position.x;

        float minX = horizontalGreen.position.x - horizontalGreen.rect.width / 2;
        float maxX = horizontalGreen.position.x + horizontalGreen.rect.width / 2;

        if (indicatorX >= minX && indicatorX <= maxX)
        {
            Debug.Log("ПОПАЛ ✅");

            gameManager.WinMiniGame(1);
        }
        else
        {
            Debug.Log("ПРОМАЗАЛ ❌");
        }
    }

}